using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarComienzoMovil : MonoBehaviour
{
    [SerializeField] private GameObject empezar;
    [SerializeField] private GameObject empezarCapa;
    void Awake()
    {
        Time.timeScale = 0;
    }

    public void Empezar()
    {
        empezar.SetActive(true);
        empezarCapa.SetActive(true);
        gameObject.SetActive(false);
    }
}
