using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f; 
    private Transform transformar;

    private void Start()
    {
        transformar = GetComponent<Transform>();
    }
    private void Update()
    {
        transformar.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
