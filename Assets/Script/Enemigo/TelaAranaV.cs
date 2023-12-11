using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaAranaV : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 movimiento;
    private bool x = true;
    [SerializeField] private GameObject Particula;
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
            DestruirConRetardo();
        }
        if (col.gameObject.CompareTag("Chancla"))
        {
            DestruirConRetardo();
        }
        if (col.gameObject.CompareTag("BalaPower"))
        {
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
