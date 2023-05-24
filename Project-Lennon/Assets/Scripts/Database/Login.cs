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
        form.AddField("name", nameField.text);//form'a name alaný ekle
        form.AddField("password", passwordField.text);//form'a password alaný ekle
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);//login.php'ye eriþim saðla
        yield return www;//eriþim saðladýktan sonra www'yi ver.
        if (www.text[0] == '0') //eðer text arrayinin ilk elementi 0 ise yani baþarýyla giriþ saðlandýðýnda
        {
            DBManager.username = nameField.text;
            DBManager.score = int.Parse(www.text.Split('\t')[1]);
            SceneManager.LoadScene("MainRegistration");
        }
        else
        {
            Debug.Log("Kullanýcý giriþi baþarýsýz oldu. Error #" + www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 6 && passwordField.text.Length >= 6);
    }
}
