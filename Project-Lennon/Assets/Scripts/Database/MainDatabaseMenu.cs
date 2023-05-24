using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainDatabaseMenu : MonoBehaviour
{
   public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterMenu");
    }
}
