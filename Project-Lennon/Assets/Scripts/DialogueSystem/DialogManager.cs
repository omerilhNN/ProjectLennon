using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform backgroundBox;


    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    public static DialogManager instance { get; private set; } //Singleton methot ile class dýþarýsýndan ulaþabilmeyi ayarladýk
    private void Awake()
    {
        instance = this; //Singleton ile instance'ý bu scripte eþitledik
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    { //Parametre olarak gönderilen verileri, scriptteki deðiþkenlere atadýk
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;

        Debug.Log("Loaded messages: " + messages.Length);

        //Mesajlarý göster fonksiyonu çaðýrýldý.
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo(); //Scale'ini (1,1,1) yap, 0.5 saniye içerisinde.EaseInOutExpo daha yumuþak bir geçim için.
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage]; //Message classýndan oluþturulan objeyi currentMessages[] arrayindeki "activeMessage" indexine ulaþtýk.
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];//Actor classýndan oluþturulan objeyi currentActors[] arrayindeki "actorId" indexine ulaþtýk.
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
    }
    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation Ended");

            //Scale'ini (0,0,0) yap, 0.5 saniye içerisinde.EaseInOutExpo daha yumuþak bir geçim için.
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }
    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0); //Mesajlarýn renginin alfasýný 0 yap, 0 saniye içerisinde. 
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);//Mesajlarýn renginin alfasýný 1 yap, 0.5 saniye içerisinde. 
    }
    private void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }
}