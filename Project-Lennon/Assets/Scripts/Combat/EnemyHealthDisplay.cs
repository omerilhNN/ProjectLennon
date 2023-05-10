using RPG.Attributes;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Combat
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        Fighter fighter;

        private void Awake()
        {   
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }
        private void Update()
        {
            if(fighter.GetTarget() == null)
            {
                GetComponent<TMP_Text>().text = "N/A";
                return;
            }
            Health health = fighter.GetTarget();

            //String formatter in order to hide decimal numbers.
            //First 0 is order and the second one is how many number that we want to show as decimal.
            GetComponent<TMP_Text>().text = String.Format("{0:0}/{1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints());  
        }
    }

}