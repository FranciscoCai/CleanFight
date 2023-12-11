using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioMusica : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip MusicaInicial;
    public AudioClip MusicaBoss;
    AudioListener listener;

    private void Start()
    {
        listener = GetComponent<AudioListener>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.clip = MusicaInicial;
        audioSource.Play();
    }
    public void musicaInicial()
    {
        audioSource.Stop();
        audioSource.clip = MusicaInicial;
        audioSource.Play();
    }
    public void musicaBoss()
    {
        audioSource.Stop();
        audioSource.clip = MusicaBoss;
        audioSource.Play();
    }
    public void EmpezarMusica()
    {
        listener.enabled = true;
    }
    public void PararMusica()
    {
        listener.enabled = false;
        Time.timeScale = 0f;
    }
}
