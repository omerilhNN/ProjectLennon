using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Stats
{
    public class LevelDisplay : MonoBehaviour
    {
        BaseStats baseStats;

        private void Awake()
        {
            baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        }
        private void Update()
        {
            //String formatter in order to hide decimal numbers.
            //First 0 is order and the second one is how many number that we want to show as decimal.
            GetComponent<TMP_Text>().text = String.Format("{0:0}", baseStats.GetLevel());  
        }
    }

}