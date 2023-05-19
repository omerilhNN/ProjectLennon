using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public DialogTrigger trigger;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
        }
    }
}
