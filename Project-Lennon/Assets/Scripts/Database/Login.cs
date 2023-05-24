using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());

    }
    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);//form'a name alan� ekle
        form.AddField("password", passwordField.text);//form'a password alan� ekle
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);//login.php'ye eri�im sa�la
        yield return www;//eri�im sa�lad�ktan sonra www'yi ver.
        if (www.text[0] == '0') //e�er text arrayinin ilk elementi 0 ise yani ba�ar�yla giri� sa�land���nda
        {
            DBManager.username = nameField.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene("MainRegistration");
        }
        else
        {
            Debug.Log("Kullan�c� giri�i ba�ar�s�z oldu. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 6 && passwordField.text.Length >= 6);
    }
}
