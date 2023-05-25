using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainDatabaseMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button playButton;

    public TMP_Text playerDisplay;
    private void Start()
    {
        if(DBManager.LoggedIn)
        {
            playerDisplay.text = "Kullanici Adi: " + DBManager.username;
        }
        registerButton.interactable = !DBManager.LoggedIn;
        loginButton.interactable= !DBManager.LoggedIn;
        playButton.interactable = DBManager.LoggedIn;
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterMenu");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene("LoginMenu");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
}
