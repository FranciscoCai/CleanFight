using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class traslate : MonoBehaviour
{
    [SerializeField] private Transform pontA;
    [SerializeField] private Transform pontB;
    [SerializeField] private Transform pontC;
    [SerializeField] private Transform pontAB;
    [SerializeField] private Transform pontBC;
    [SerializeField] private Transform pontAB_BC;
    private float x;
    private float y;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = (x + Time.deltaTime) % 1f;
        pontAB.position = Vector3.Lerp(pontA.position, pontB.position, x);
        pontBC.position = Vector3.Lerp(pontA.position, pontC.position, x);
        pontAB_BC.position = Vector3.Lerp(pontAB.position, pontBC.position, x);
    }
}
