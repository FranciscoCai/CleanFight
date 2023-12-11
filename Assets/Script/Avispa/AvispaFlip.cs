using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvispaFlip : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector3 Camara;
    private float Max;
    private float Min;
    public Vector3 movimiento;
    private bool flipMax;
    private bool flipMin;
    public static AvispaFlip instance { get; private set; }

    [SerializeField] private float VelocidadxFase1;
    [SerializeField] private float VelocidadxFase2;

    private void Awake()
    {
        instance = this;
        flipMax = true;
        flipMin = true;
        Camara = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
        Max = Camara.x - (gameObject.transform.localScale.x / 2);
        Min = -Camara.x + (gameObject.transform.localScale.x / 2);
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        rb2D.velocity = movimiento;
        if (rb2D.position.x >= Max && flipMax == true)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1f;
            transform.localScale = newScale;
            movimiento = new Vector2(-movimiento.x, movimiento.y);
            flipMin = true;
            flipMax = false;
        }
        else if(rb2D.position.x <= Min && flipMin == true)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1f;
            transform.localScale = newScale;
            movimiento = new Vector2(-movimiento.x, movimiento.y);
            flipMax = true;
            flipMin = false;
        }
    }
    public void Fase1()
    {
        movimiento.x = VelocidadxFase1 * movimiento.x;
    }
    public void Fase2()
    {
        movimiento.x = VelocidadxFase2 * movimiento.x;
    }
    public void velocidad()
    {
        rb2D.velocity = movimiento;
    }

}
