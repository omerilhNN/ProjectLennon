using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class veriGetir : MonoBehaviour
{
    public string[] gelen_veriler = new string[10];//Formdan gelen veriler için array
    public TMP_Text[] textler;
    void Start()
    {
        StartCoroutine(kayit_cek());
    }
    
    IEnumerator kayit_cek()
    {
        WWWForm form = new WWWForm();
        form.AddField("komut", "veriCekme");
        string url = "http://localhost/sqlconnect/scoreboard.php";
        WWW w = new WWW(url, form);
        yield return w;
        gelen_veriler = w.text.Split(';');

        for(int i =0; i < gelen_veriler.Length; i++)
        {
            textler[i].text = "" + gelen_veriler[i];   

        }
        Debug.Log(w.text);
    }
}
