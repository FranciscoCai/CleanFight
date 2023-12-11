using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 movimiento;
    [SerializeField] private GameObject Explosion;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = movimiento;
        Invoke("AutoDestruir", 2f);
    }
   
    private void AutoDestruir()
    {
        Destroy(gameObject);
    }

    public void Invocar()
    {
        Instantiate(Explosion,transform.localPosition,Quaternion.identity);
        Destroy(gameObject);
    }

}
