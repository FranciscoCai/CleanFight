using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioVelocidadEnemigo : MonoBehaviour
{
    [SerializeField] private GameObject enemigoCambioVelocidad1;
    [SerializeField] private float velocidadACambiar1;
    [SerializeField] private GameObject enemigoCambioVelocidad2;
    [SerializeField] private float velocidadACambiar2;
    [SerializeField] private GameObject enemigoCambioVelocidad3;
    [SerializeField] private float velocidadACambiar3;
    [SerializeField] private GameObject enemigoCambioVelocidad4;
    [SerializeField] private float velocidadACambiar4;
    [SerializeField] private GameObject enemigoCambioVelocidad5;
    [SerializeField] private float velocidadACambiar5;
    private void Start()
    {
        if (enemigoCambioVelocidad1 != null)
        {
            GameManager.instance.CambioVelocidad(enemigoCambioVelocidad1, velocidadACambiar1);
        }
        if (enemigoCambioVelocidad2 != null)
        {
            GameManager.instance.CambioVelocidad(enemigoCambioVelocidad2, velocidadACambiar2);
        }
        if (enemigoCambioVelocidad3 != null)
        {
            GameManager.instance.CambioVelocidad(enemigoCambioVelocidad3, velocidadACambiar3);
        }
        if (enemigoCambioVelocidad4 != null)
        {
            GameManager.instance.CambioVelocidad(enemigoCambioVelocidad4, velocidadACambiar4);
        }
        if (enemigoCambioVelocidad5 != null)
        {
            GameManager.instance.CambioVelocidad(enemigoCambioVelocidad5, velocidadACambiar5);
        }
    }
}
