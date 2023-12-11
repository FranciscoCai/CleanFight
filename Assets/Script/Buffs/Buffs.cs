using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    private Vector3 Camara;
    private float AlturaMaxima;
    private float AlturaMinima;
    private Vector2 Movimiento;
    private float Velocidadx;
    private float Velocidady;
    private Vector2 Velocidad;
    private Rigidbody2D rb2;
    [SerializeField] private bool x;
    void Start()
    {
        Debug.Log(Screen.height);
        rb2 = GetComponent<Rigidbody2D>();
        Camara = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
        Velocidadx = Random.Range(0.15f,0.25f );
        Velocidady = Random.Range(1.5f,2.5f);
        AlturaMaxima = Random.Range(0.6f * Camara.y, 0.85f * Camara.y);
        AlturaMinima = Random.Range(-0.3f * Camara.y, 0.3f * Camara.y);
        if(gameObject.transform.localPosition.x > 0)
        {
            Velocidad = new Vector2(-Velocidadx, Velocidady);
        }
        else
        {
            Velocidad = new Vector2(+Velocidadx, Velocidady);
        }
        rb2.GetComponent<Rigidbody2D>().velocity = Velocidad;
    }

    void Update()
    {
        if(x == true && gameObject.transform.localPosition.y >AlturaMaxima)
        {
            rb2.GetComponent<Rigidbody2D>().velocity = new Vector2(rb2.GetComponent<Rigidbody2D>().velocity.x, -Velocidady);
            x = false;
            AlturaMaxima = Random.Range(0.6f * Camara.y, 0.85f * Camara.y);
        }
        if (x == false && gameObject.transform.localPosition.y < AlturaMinima)
        {
            rb2.GetComponent<Rigidbody2D>().velocity = new Vector2(rb2.GetComponent<Rigidbody2D>().velocity.x, Velocidady);
            x = true;
            AlturaMinima = Random.Range(-0.3f * Camara.y, 0.2f * Camara.y);
        }
    }
}
