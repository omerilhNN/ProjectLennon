using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NPCDialog : MonoBehaviour
{
    public DialogTrigger trigger;
    public GameObject endGamePanel;

    [SerializeField] GameObject player;
    [SerializeField] Canvas pauseMenuCanvas;
    NavMeshAgent agent;
    PauseMenu pauseMenu;

    private void Awake()
    {
        agent = player.GetComponent<NavMeshAgent>();
        pauseMenu = pauseMenuCanvas.GetComponent<PauseMenu>();
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
        if(other.gameObject.CompareTag("Player") == true && SceneManager.GetActiveScene().buildIndex == 6)
        {
            pauseMenu.CallSaveData();
            endGamePanel.SetActive(true);
            agent.enabled = false;
        }
    }
}
