using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Explicacion : MonoBehaviour
{
    private int x = 0;
    [SerializeField] private GameObject Habilida;
    [SerializeField] private GameObject fuego;
    [SerializeField] private GameObject Agua;
    [SerializeField] private GameObject Chancla;
    [SerializeField] private GameObject Explicar;
    [SerializeField] private GameObject CapaOscura;
    [SerializeField] private GameObject Ronda;
    public void Empieza()
    {
        if(x == 0)
        {
            x++;
            fuego.SetActive(true);
            Destroy(Habilida);
        }
        else
        {
            Time.timeScale = 1f;
            fuego.SetActive(false);
            Agua.SetActive(false);
            Chancla.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    public void Comenzar()
    {
        Explicar.SetActive(false);
        CapaOscura.SetActive(true);
        Ronda.SetActive(true);
        gameObject.SetActive(false);
    }
}
