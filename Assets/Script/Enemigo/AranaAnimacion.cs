using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AranaAnimacion : MonoBehaviour
{
    [SerializeField] private GameObject Tela;
    [SerializeField] private AudioClip SonidoDisparo;
    [SerializeField] private float x;
    private AudioSource Sonido;

    private void Start()
    {
        Sonido = GetComponent<AudioSource>();
    }
    public void Quiueto()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    public void Activo()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    public void Disparo()
    {
        Sonido.PlayOneShot(SonidoDisparo);
        Instantiate(Tela, new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - x), Quaternion.identity);
    }
}
