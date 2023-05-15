using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TextMeshProUGUI volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Confirmation")]
    [SerializeField] private GameObject confirmationPrompt = null;

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
