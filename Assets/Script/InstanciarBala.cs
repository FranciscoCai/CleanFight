using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarBala : MonoBehaviour
{
    private GameObject Bala;
    [SerializeField] public GameObject BalaNormal;
    [SerializeField] public GameObject BalaPower;
    private Camera mainCamera;
    [SerializeField] private AudioClip SonidoDisparo;
    private AudioSource Sonido;
   
    public static InstanciarBala instance { get; private set; }

    public void Awake()
    {
        Sonido = GetComponent<AudioSource>();
        instance = this;
        Bala = BalaNormal;
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void LugarInstanciar()
    {
        Sonido.PlayOneShot(SonidoDisparo);
        Instantiate(Bala, gameObject.transform.position, Quaternion.identity);
    }
    public void PowerUp()
    {
        Bala = BalaPower;
        Instantiate(Bala, gameObject.transform.position, Quaternion.identity);
        Bala = BalaNormal;
    }


}
