using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    public void StartDialogue()
    {
        DialogManager.instance.OpenDialogue(messages,actors);
    }

}
[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}
[System.Serializable]
public class Actor
{
    public string name  ;
    public Sprite sprite;       
}
