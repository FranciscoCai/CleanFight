using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioVelocidadInvocar : MonoBehaviour
{
    [SerializeField] private float velocidadDeIncocacion;
    void Start()
    {
        if (velocidadDeIncocacion != 0)
        {
            Ejemplo.instance.InstanciarDelay = velocidadDeIncocacion;
        }
    }
}
