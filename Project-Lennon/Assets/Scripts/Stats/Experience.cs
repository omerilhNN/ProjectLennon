using UnityEngine;
using RPG.Saving;
using System;

namespace RPG.Stats 
{
    public class Experience : MonoBehaviour,ISaveable
    {
        [SerializeField] float experiencePoints = 0f;

        public event Action onExperienceGained; // predefined delegate without return value.

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
            onExperienceGained(); //We already added a delegate to that Action in BaseStats script.
        }
        public float GetPoints()
        {
            return experiencePoints;
        }
        public object CaptureState()
        {
            return experiencePoints;
        }
        public void RestoreState(object state)
        {
            experiencePoints = (float)state;
        }

        
    }
}