using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCiempies : MonoBehaviour
{
    public static MovimientoCiempies instance { get; private set; }
    private Rigidbody2D rb;
    public Vector3 movimiento;
    public Vector3 VelocidadInicial;
    public bool CiempiesMuerte;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        VelocidadInicial = movimiento;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = movimiento;
    }
    public void velocidad()
    {
        if(CiempiesMuerte == true)
        {
            rb.velocity = movimiento;
        }
    }
}
