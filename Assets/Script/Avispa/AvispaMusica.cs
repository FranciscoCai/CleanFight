using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvispaMusica : MonoBehaviour
{
    [SerializeField] private GameObject Camara;
    private void Start()
    {
        Camara.GetComponent<CambioMusica>().musicaBoss();
    }
}
