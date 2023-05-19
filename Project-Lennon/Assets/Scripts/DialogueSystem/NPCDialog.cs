using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCDialog : MonoBehaviour
{
    public DialogTrigger trigger;
    public GameObject endGamePanel;

    [SerializeField] GameObject player;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = player.GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") == true && SceneManager.GetActiveScene().buildIndex == 3)
        {
            endGamePanel.SetActive(true);
            agent.enabled = false;
        }
    }
}
