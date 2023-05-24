using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());

    }

  IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password",passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php",form);
        yield return www;
        if (www.text == "0")//Eðer hata yoksa kullanýcý oluþturuldu.
        {
            Debug.Log("User created succesfully");
            SceneManager.LoadScene("MainRegistration");
        }
        else
        {
            Debug.Log("User creation failed. Error code: #" +www.text);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 6 && passwordField.text.Length >= 6);
    }
}
