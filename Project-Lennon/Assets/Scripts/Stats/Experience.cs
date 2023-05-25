using UnityEngine;
using RPG.Saving;
using System;
using System.Collections;

namespace RPG.Stats 
{
    public class Experience : MonoBehaviour,ISaveable
    {
        [SerializeField] float experiencePoints = 0f;

        public event Action onExperienceGained; // predefined delegate without return value.

        private void Awake()
        {
            if (DBManager.username == null)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
            DBManager.score = experiencePoints;

            onExperienceGained(); //We already added a delegate to that Action in BaseStats script.
        }
      /*  public void CallSaveData()
        {
            StartCoroutine(SavePlayerData());
        }
        IEnumerator SavePlayerData()
        {
            WWWForm form = new WWWForm();
            form.AddField("name", DBManager.username);
            form.AddField("score", Convert.ToString(DBManager.score));

            WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form);
            yield return www;
            if (www.text == "0")
            {
                Debug.Log("Data saved");
            }
            else
            {
                Debug.Log("Save failed. Error #" + www.text);
            }
            DBManager.LogOut();
            
        }*/
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