using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoArana : MonoBehaviour
{
    public static MovimientoArana instance { get; private set; }
    private Rigidbody2D rb;
    public Vector3 movimiento;
    public Vector3 VelocidadInicial;
    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        VelocidadInicial = movimiento;
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        rb.velocity = movimiento;
    }
}
