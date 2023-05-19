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

    public static DialogManager instance { get; private set; } //Singleton methot ile class d��ar�s�ndan ula�abilmeyi ayarlad�k
    private void Awake()
    {
        instance = this; //Singleton ile instance'� bu scripte e�itledik
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    { //Parametre olarak g�nderilen verileri, scriptteki de�i�kenlere atad�k
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        isActive = true;

        Debug.Log("Loaded messages: " + messages.Length);

        //Mesajlar� g�ster fonksiyonu �a��r�ld�.
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo(); //Scale'ini (1,1,1) yap, 0.5 saniye i�erisinde.EaseInOutExpo daha yumu�ak bir ge�im i�in.
    }
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage]; //Message class�ndan olu�turulan objeyi currentMessages[] arrayindeki "activeMessage" indexine ula�t�k.
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];//Actor class�ndan olu�turulan objeyi currentActors[] arrayindeki "actorId" indexine ula�t�k.
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

            //Scale'ini (0,0,0) yap, 0.5 saniye i�erisinde.EaseInOutExpo daha yumu�ak bir ge�im i�in.
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }
    void AnimateTextColor()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0); //Mesajlar�n renginin alfas�n� 0 yap, 0 saniye i�erisinde. 
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);//Mesajlar�n renginin alfas�n� 1 yap, 0.5 saniye i�erisinde. 
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