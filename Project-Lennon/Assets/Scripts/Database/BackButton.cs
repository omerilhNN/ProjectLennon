using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void GoToMainRegistration()
    {
        SceneManager.LoadScene("MainRegistration");
    }
}
