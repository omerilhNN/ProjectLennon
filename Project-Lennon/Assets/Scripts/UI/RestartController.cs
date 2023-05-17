using RPG.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private GameObject restartGamePanel = null;
    private void Start()
    {
        health = GetComponent<Health>();
       
    }
    private void Update()
    {
        if (health.IsDead())
        {
            //Restart butonu ��ks�n ve oyun zaman� durdurulsun
            Time.timeScale = 0f;
            restartGamePanel.SetActive(true);
        }
    }

    public void ResetGame()
    {
        //Level'� yeniden y�kleyip oyun zaman�n� normal zamana d�ndersin.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
