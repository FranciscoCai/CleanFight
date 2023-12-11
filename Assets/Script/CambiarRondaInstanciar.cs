using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarRondaInstanciar : MonoBehaviour
{
    [SerializeField] private float numeroACambiar;
    void Start()
    {
        Ejemplo.instance.CambiarInstanciar(numeroACambiar);
    }

}
