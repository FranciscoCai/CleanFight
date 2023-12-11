using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstaciaMosquito : MonoBehaviour
{
    [SerializeField] private GameObject Mosquito;

    private void Incocar()
    {
        Vector2 position = new Vector2(transform.localPosition.x, transform.localPosition.y);
        Instantiate(Mosquito,position, Quaternion.identity);
        Destroy(gameObject);
    }
}
