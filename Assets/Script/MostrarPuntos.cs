using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarPuntos : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Texto;
    [SerializeField] TextMeshProUGUI PWcd;
    [SerializeField] TextMeshProUGUI PWacd;
    [SerializeField] TextMeshProUGUI PWccd;
    public static MostrarPuntos instance { get; private set; }

    private void Start()
    {
        instance = this;
        PWcd.text = GameManager.instance.CD.ToString();
        PWacd.text = GameManager.instance.CDA.ToString();
        PWccd.text = GameManager.instance.CCD.ToString();
    }
    public void PuntosCanvas()
    {
       Texto.text = GameManager.instance.PuntosCompartidos.ToString();
    }
    public void PWCD()
    {
        PWcd.text = GameManager.instance.CD.ToString();
    }
    public void PWACD()
    {
        PWacd.text = GameManager.instance.CDA.ToString();
    }
    public void PWCCD()
    {
        PWccd.text = GameManager.instance.CCD.ToString();   
    }
}
