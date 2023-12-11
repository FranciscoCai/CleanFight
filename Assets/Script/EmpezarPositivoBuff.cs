using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarPositivoBuff : MonoBehaviour
{
    void Start()
    {
        GameManager.RondaDelate = false;
        GameManager.VidaPorPrimaraVez = true;
    }
}
