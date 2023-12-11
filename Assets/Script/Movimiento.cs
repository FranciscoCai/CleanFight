using System.Collections;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public static Movimiento instance { get; private set; }
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
        float rotationAngle = transform.eulerAngles.z;
        float rotationRad = rotationAngle * Mathf.Deg2Rad;
        Vector3 rotatedMovement = new Vector3(
            Mathf.Cos(rotationRad) * movimiento.x - Mathf.Sin(rotationRad) * movimiento.y,
            Mathf.Sin(rotationRad) * movimiento.x + Mathf.Cos(rotationRad) * movimiento.y,
            movimiento.z
        );

        rb.velocity = rotatedMovement;
    }
}

