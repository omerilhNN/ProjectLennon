using GameDevTV.Utils;
using RPG.Core;
using RPG.Saving;
using RPG.Stats;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace RPG.Attributes
{
    public class Health : MonoBehaviour,ISaveable
    {
        [SerializeField] float regenerationPercentage = 80f;
        [SerializeField] UnityEvent<float> takeDamage;//When we take damage DamageText shows and slowly fades away by EVENT. Also, DamageTaken sFX played.
        [SerializeField] UnityEvent onDie;

        LazyValue<float> _health;

        bool isDead = false;
        private void Awake()
        {
            _health = new LazyValue<float>(GetInitialHealth);
        }
        private float GetInitialHealth()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        private void Start()
        {
            _health.ForceInit();
        }
        private void OnEnable()
        {//Add regenerate method to this particular onLevelUp Action event list in BaseStats.cs.
            GetComponent<BaseStats>().onLevelUp += RegenerateHealth;
        }
        private void OnDisable()
        {
            GetComponent<BaseStats>().onLevelUp -= RegenerateHealth;
        }

        public bool IsDead() { return isDead; }

        public void TakeDamage(GameObject instigator,float damage)
        {
            _health.value = Mathf.Max(_health.value - damage, 0);

            if (_health.value == 0)
            {
                onDie.Invoke();//Invoke die SFX when health equals 0;
                gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
                Die();
                AwardExperience(instigator);
            }
            else
            {//give "damage" paramater to it in order to see the real damage that has been given.
                takeDamage.Invoke(damage);//Assigned DamageTextSpawner script as an EVENT in the inspector. Called it everytime when character took damage.
            }
        }
        public void Heal(float healthToRestore)
        {
            _health.value = Mathf.Min(_health.value + healthToRestore, GetMaxHealthPoints());
        }
        public float GetHealthPoints()
        {
            return _health.value;
        }
        public float GetMaxHealthPoints()
        {
            return GetComponent<BaseStats>().GetStat(Stat.Health);
        }

        public float GetPercentage()
        {
            return 100 * GetFraction();
        }
        public float GetFraction()
        {
            return _health.value / GetComponent<BaseStats>().GetStat(Stat.Health);
        }
        private void Die()
        {
            if (isDead) return;

            isDead = true;
            GetComponent<Animator>().SetTrigger("die");

            //GO is no longer available to move or attack due to that method down below.
            GetComponent<ActionScheduler>().CancelCurrentAction();

           
        }
        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience == null) return;

            experience.GainExperience(GetComponent<BaseStats>().GetStat(Stat.ExperienceReward));
        }
        private void RegenerateHealth()
        {
            float regenHealthPoints = GetComponent<BaseStats>().GetStat(Stat.Health) * (regenerationPercentage /100);
            _health.value = Mathf.Max(_health.value, regenHealthPoints);
        }
      
        public object CaptureState()
        {
            return _health.value;
        }
        public void RestoreState(object state)
        {
            _health.value = (float)state;

            if (_health.value == 0)
            {
                Die();
            }
        }

        
    }
}
