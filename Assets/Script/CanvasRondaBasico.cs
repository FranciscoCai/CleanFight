using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRondaBasico : MonoBehaviour
{

    [SerializeField] private float NumeroACambiar;
    private void Start()
    {
        Ejemplo.instance.numeroMinimo = NumeroACambiar;
    }

}
