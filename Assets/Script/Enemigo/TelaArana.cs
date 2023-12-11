using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TelaArana : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 movimiento;
    private bool x = true;
    [SerializeField] private GameObject Particula;
    [SerializeField] private GameObject burbuja;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = movimiento;
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Bala"))
        {
            Destroy(col.gameObject);
            DestruirConRetardo();
            Instantiate(burbuja, gameObject.transform.position, Quaternion.identity);
        }
        if (col.gameObject.CompareTag("Chancla"))
        {
            DestruirConRetardo();
        }
        if (col.gameObject.CompareTag("BalaPower"))
        {
            if (col.gameObject.GetComponent<Disparo>() != null)
            {
                col.gameObject.GetComponent<Disparo>().Invocar();
            }
            DestruirConRetardo();

        }
    }
    private void DestruirConRetardo()
    {
        if (x == true)
        {
            x = false;
            Instantiate(Particula, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}

