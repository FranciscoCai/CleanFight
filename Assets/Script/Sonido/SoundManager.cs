using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource Sonido;
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        Sonido = GetComponent<AudioSource>();
            LoadVolume();
    }
    public void SonidoGolpe(AudioClip sound)
    {
        Sonido.PlayOneShot(sound);
    }
    public void ReproducirSonido(AudioClip sound)
    {
        Sonido.PlayOneShot(sound);
    }
    public float volume;
    public float volumesfx;
    public void SetMusicVolume()
    {
        volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);

    }
    public void SetSFXVolume()
    {
        volumesfx = sfxSlider.value;
        myMixer.SetFloat("sfx", Mathf.Log10(volumesfx) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volumesfx);

    }
    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
           sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        }
        SetMusicVolume();
        SetSFXVolume();
    }
    private void FixedUpdate()
    {
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        myMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
    }
}
