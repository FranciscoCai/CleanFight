using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiroMosca : MonoBehaviour
{
    [SerializeField]
    private bool DuracionCorutina;
    private float Contador;
    private float duracion;
    private Vector3 Camara;
    [SerializeField] private float Giro;

    private void Start()
    {
        Camara = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
        DuracionCorutina = true;
        int Aleatoriedad = Random.Range(1, 3);
        if (transform.localPosition.x > Camara.x - 2)
        {
            StartCoroutine(IzquierdaMosca());
        }
        else if(transform.localPosition.x < -Camara.x + 2)
        {
            StartCoroutine(DerechaMosca());
        }
        else if(Aleatoriedad == 1)
        {
            StartCoroutine(IzquierdaMosca());
        }
        else
        {
            StartCoroutine(DerechaMosca());
        }
    }
    private IEnumerator DerechaMosca()
    {
        duracion = Random.Range(0.5f, 1f);
        while (DuracionCorutina == true)
        {
            Contador = Contador + Time.deltaTime;
            transform.Rotate(Vector3.forward, +15 * Time.deltaTime * Giro);
            if (Contador >= duracion)
            {
                DuracionCorutina = false;
            }
            yield return null;
        }
        Contador = 0;
        DuracionCorutina = true;
        if(transform.localPosition.x > Camara.x - 1.5)
        {
            Invoke("CorutinaIzquierda", 0);
        }
        else if (transform.localPosition.x < -Camara.x + 1.5)
        {
            Invoke("CorutinaDerecha", 0);
        }
        else if (gameObject.transform.rotation.z <= -0.1)
        {
            Invoke("CorutinaDerecha", 0);
        }
        else
        {
            Invoke("CorutinaIzquierda", 0);
        }
    }
    private IEnumerator IzquierdaMosca()
    {
        duracion = Random.Range(0.25f, 0.75f);
        while (DuracionCorutina == true)
        {
            Contador = Contador + Time.deltaTime;
            transform.Rotate(Vector3.forward, -15 * Time.deltaTime * Giro);
            if (Contador >= duracion)
            {
                DuracionCorutina = false;
            }
            yield return null;
        }
        Contador = 0;
        DuracionCorutina = true;
        if (transform.localPosition.x < -Camara.x + 1.5)
        {
            Invoke("CorutinaDerecha", 0);
        }
        else if (transform.localPosition.x > Camara.x - 1.5)
        {
            Invoke("CorutinaIzquierda", 0);
        }
        else if (gameObject.transform.rotation.z <= 0.1)
        {
            Invoke("CorutinaDerecha", 0);
        }
        else
        {
            Invoke("CorutinaIzquierda", 0);
        }
    }
    private void CorutinaDerecha()
    {
        StartCoroutine(DerechaMosca());
    }
    private void CorutinaIzquierda()
    {
        StartCoroutine(IzquierdaMosca());
    }
    private void Update()
    {
        if (transform.localPosition.x < -Camara.x + 0.1*Camara.x || transform.localPosition.x > +Camara.x - 0.1 * Camara.x)
        {

            Giro = 3;

        }
        else { 

            Giro = 1;
        
        }

    }
}
