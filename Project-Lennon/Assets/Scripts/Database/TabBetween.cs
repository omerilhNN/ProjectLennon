using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMP_InputField))]
public class TabBetween : MonoBehaviour
{
    public TMP_InputField nextInputField;
    TMP_InputField myField;
    // Start is called before the first frame update
    void Start()
    {
        if(nextInputField == null) 
        {
            Destroy(this);
            return; 
        }
        myField = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
         if(myField.isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            nextInputField.ActivateInputField();                
        }
    }
}
