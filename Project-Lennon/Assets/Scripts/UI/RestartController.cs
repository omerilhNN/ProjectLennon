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
        { //Karakter �ld�yse restart paneli belirli saniye sonunda aktifle�tir ve sonras�nda oyun zaman�n� durdur.
            StartCoroutine(ResetPanel());
        }
    }

    public void ResetGame()
    {
        //Level'� yeniden y�kleyip oyun zaman�n� normal zamana d�ndersin.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public IEnumerator ResetPanel()
    {
        yield return new WaitForSeconds(1f);
        restartGamePanel.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        Time.timeScale = 0f;
    }
}
