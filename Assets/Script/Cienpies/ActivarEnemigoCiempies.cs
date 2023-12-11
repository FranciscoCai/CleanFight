using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEnemigoCiempies : MonoBehaviour
{
    [SerializeField] private GameObject Camara;
    void Start()
    {
        GameManager.RondaDelate = true;
        GameManager.VidaPorPrimaraVez = true;
        if (Camara != null)
        {
            Camara.GetComponent<CambioMusica>().musicaBoss();
        }
    }
}
