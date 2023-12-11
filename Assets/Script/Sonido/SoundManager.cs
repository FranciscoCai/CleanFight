using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource Sonido;

    private void Start()
    { 
        instance = this;
        Sonido = GetComponent<AudioSource>();
    }
    public void SonidoGolpe(AudioClip sound)
    {
        Sonido.PlayOneShot(sound);
    }
    public void ReproducirSonido(AudioClip sound)
    {
        Sonido.PlayOneShot(sound);
    }
}
