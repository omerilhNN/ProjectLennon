using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webtest : MonoBehaviour
{
    IEnumerator Start()
    {
        WWW request = new WWW("http://localhost/sqlconnect/webtest.php");
        yield return request;
        Debug.Log(request.text);
    }
}
