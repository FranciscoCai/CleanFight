using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviso : MonoBehaviour
{
    [SerializeField] private GameObject Boss;

    public void ActivarBoss()
    {
        Boss.SetActive(true);
        Destroy(gameObject);
    }

}
