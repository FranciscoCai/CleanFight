using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelimitarHabilidad : MonoBehaviour
{
    [SerializeField] private GameObject Habilidad;
    [SerializeField] private GameObject subhabilidad;
    [SerializeField] private GameObject Oscuro;
    [SerializeField] private GameObject DistintaHabilidadExplicacion;
    [SerializeField] private GameObject CanvasHabilidadExplicaion;
    [SerializeField] private GameObject Efecto;


    private void Start()
    {
        DistintaHabilidadExplicacion.SetActive(true);
        CanvasHabilidadExplicaion.SetActive(true);
        Habilidad.SetActive(true);
        if (GameManager.instance.HabilidadStart == 0)
        {
            GameManager.instance.cd = 5;
            GameManager.instance.MostrarOscuroCd();
            Efecto.SetActive(false);
        }
        else if (GameManager.instance.HabilidadStart == 1)
        {
            GameManager.instance.cda = 5;
            GameManager.instance.MostrarOscuroCda();
            Efecto.SetActive(false );
        }
        else if (GameManager.instance.HabilidadStart == 2)
        {
            GameManager.instance.ccd = 10;
            GameManager.instance.MostrarOscuroCcd();
            Efecto.SetActive(false);
        }
        GameManager.instance.HabilidadStart++;
        MostrarPuntos.instance.PWACD();
        MostrarPuntos.instance.PWCD();
        MostrarPuntos.instance.PWCCD();
        subhabilidad.SetActive(false);
        Time.timeScale = 0f;
        Oscuro.SetActive(true);
    }
}
