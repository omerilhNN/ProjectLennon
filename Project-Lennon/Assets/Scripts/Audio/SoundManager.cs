using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
   public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name) //�al�nacak clip ile halihaz�rda �al��an scriptlerin �ak��mamas� ve seslerin �st �ste binmemesi i�in
            return;
        //�al�nan sesi durdur, di�er �al�nacak sesi AudioSource'un clip k�sm�na atama yap ve tekrar ba�lat.
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

}
