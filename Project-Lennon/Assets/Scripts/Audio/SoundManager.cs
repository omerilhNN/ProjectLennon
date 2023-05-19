using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
   public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name) //çalýnacak clip ile halihazýrda çalýþan scriptlerin çakýþmamasý ve seslerin üst üste binmemesi için
            return;
        //Çalýnan sesi durdur, diðer çalýnacak sesi AudioSource'un clip kýsmýna atama yap ve tekrar baþlat.
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

}
