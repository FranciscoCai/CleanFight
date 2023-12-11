using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEnemigoCanvas : MonoBehaviour
{
    [SerializeField] private float minimo;
    [SerializeField] private float maximo;
    void Start()
    {
        Ejemplo.instance.numeroMinimo = minimo;
        Ejemplo.instance.numero = maximo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
