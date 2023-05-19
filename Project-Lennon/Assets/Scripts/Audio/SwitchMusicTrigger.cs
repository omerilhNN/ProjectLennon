using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip bossTrack;

    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(bossTrack != null)
                soundManager.ChangeBGM(bossTrack);
        }
    }
}
