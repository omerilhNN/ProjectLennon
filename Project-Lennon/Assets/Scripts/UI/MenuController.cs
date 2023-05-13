using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    [SerializeField] private EventSystem _eventSystem;

    [Header("Volume Settings")]
    [SerializeField] private TextMeshProUGUI volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

    [Header("Levels to Load!")]
    public int levelToLoad=1;

    public void PlayGameYes()
    { //Level01'i yükle
        DontDestroyOnLoad(_eventSystem);
        
        SceneManager.LoadScene(levelToLoad);
    }
    public void ExitGameYes()
    { //Çýkýþ yap
        Application.Quit();
    }


    public void SetVolume(float volume)
    { //Sliderda deðiþtirilen deðeri ses deðiþkenine ata
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }
    public void ApplyVolume()
    {//Deðiþtirilen sesi kaydetmek
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }
    public IEnumerator ConfirmationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        confirmationPrompt.SetActive(false);
    }
}
