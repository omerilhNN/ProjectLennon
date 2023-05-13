using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MenuController;
using static UnityEngine.UI.ContentSizeFitter;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TextMeshProUGUI valueText = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioMixMode MixMode;

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LogarithmicMixerVolume,
        LinearMixerVolume
    }
    public void OnChangeSlider(float volume)
    {
        valueText.SetText($"{volume.ToString("N4")}");
        switch (MixMode)
        {
            case AudioMixMode.LinearAudioSourceVolume:
                AudioSource.volume = volume;
                break;
            case AudioMixMode.LinearMixerVolume:
                audioMixer.SetFloat("Volume", (-80 + volume * 100));
                break;
            case AudioMixMode.LogarithmicMixerVolume:
                audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
                break;
        }
    }
}
