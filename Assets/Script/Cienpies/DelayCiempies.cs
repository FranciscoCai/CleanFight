using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DelayCiempies : MonoBehaviour
{
    [SerializeField] private GameObject SiguienteRonda;
    [SerializeField] private GameObject SiguienteVida;
    void Start()
    {
        GameManager.RondaDelate = false;
        Invoke("Delay", 4f);
    }

    private void Delay()

    {
        SiguienteRonda.SetActive(true);
        SiguienteVida.SetActive(true);
        Destroy(gameObject);
    }
}
