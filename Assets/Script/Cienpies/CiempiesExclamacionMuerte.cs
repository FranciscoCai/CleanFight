using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiempiesExclamacionMuerte : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool x = true;
    [SerializeField] private GameObject Particula;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bala") || col.gameObject.CompareTag("Chancla") || col.gameObject.CompareTag("BalaPower"))
        {
            if (col.gameObject.CompareTag("Bala"))
            {
                Destroy(col.gameObject);
            }
            if (col.gameObject.CompareTag("BalaPower"))
            {
                if (col.gameObject.GetComponent<Disparo>() != null)
                {
                    col.gameObject.GetComponent<Disparo>().Invocar();
                }
            }
            if (gameObject.GetComponent<MovimientoCiempies>() != null)
            {
                gameObject.GetComponent<MovimientoCiempies>().CiempiesMuerte = false;
                if (VidaCiempiesFase2.instance != null)
                {
                    VidaCiempiesFase2.instance.Vida();
                }
            }
            Instantiate(Particula, col.transform.position, Quaternion.identity);
            boxCollider.enabled = false;
            rb.AddForce(Vector3.up * 15f, ForceMode2D.Impulse);
            if (x == true)
            {
                audioSource.enabled = false;
                Invoke("Muerte", 4f);
            }
        }
    }

    private void Muerte()
    {
        x = false;
        Destroy(gameObject);
    }
}
