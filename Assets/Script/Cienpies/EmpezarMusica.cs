using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarMusica : MonoBehaviour
{
    [SerializeField] private GameObject Camara;
    void Start()
    {
        Camara.GetComponent<CambioMusica>().musicaBoss();
    }
}
