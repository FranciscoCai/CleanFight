using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestarVida : MonoBehaviour
{
    [SerializeField] private Image AvisoVida;
    public int vida = 10;
    private Image imagen;
    [SerializeField] private GameObject EfectoDano;
    [SerializeField] private Sprite V100;
    [SerializeField] private Sprite V90;
    [SerializeField] private Sprite V80;
    [SerializeField] private Sprite V70;
    [SerializeField] private Sprite V60;
    [SerializeField] private Sprite V50;
    [SerializeField] private Sprite V40;
    [SerializeField] private Sprite V30;
    [SerializeField] private Sprite V20;
    [SerializeField] private Sprite V10;
    [SerializeField] private AudioClip Golpe;
    private int NumeroAleatorioVidaBuff;
    private AudioSource Source;
    public GameObject RecuperarVidaBuff;
    private Vector3 Camara;
    private Vector2 puntoDeInstancia;
    [SerializeField] private bool CambioVidaBuffDisponible;
    private Color color;
    private void Start()
    {
     CambioVidaBuffDisponible = true;
     Source = GetComponent<AudioSource>();  
     imagen = GetComponent<Image>();
     Camara = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
     color = AvisoVida.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyDisparo"))
        { }
        else { return; }
        NumeroAleatorioVidaBuff = Random.Range(0, 2);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(collision.GetComponent<CiempiesVida>() != null)
            {
                SceneManager.LoadScene("Muerte");
            }
            Destroy(collision.gameObject);
            MostrarPuntos.instance.PuntosCanvas();
            vida--;
            EfectoDano.SetActive(true);
            if (vida == 10)
            {
                imagen.sprite = V100;
            }
            else if (vida == 9)
            {
                imagen.sprite = V90;
            }
            else if (vida == 8)
            {
                imagen.sprite = V80;
            }
            else if (vida == 7)
            {
                imagen.sprite = V70;
            }
            else if (vida == 6)
            {
                imagen.sprite = V60;
            }
            else if (vida == 5)
            {
                imagen.sprite = V50;
            }
            else if (vida == 4)
            {
                imagen.sprite = V40;
            }
            else if (vida == 3)
            {
                imagen.sprite = V30;
            }
            else if (vida == 2)
            {
                imagen.sprite = V20;
            }
            else if (vida == 1)
            {
                imagen.sprite = V10;
            }
            else if (vida == 0)
            {
                SceneManager.LoadScene("Muerte");
            }
            Source.PlayOneShot(Golpe);
            if (GameManager.RondaDelate == true)
            {
                GameManager.RondaEjemplo = true;
            }
            GameManager.instance.Delate();
        }
        if (collision.gameObject.CompareTag("EnemyDisparo"))
        {
            Destroy(collision.gameObject);
            vida--;
            EfectoDano.SetActive(true);
            if (vida == 10)
            {
                imagen.sprite = V100;
            }
            else if (vida == 9)
            {
                imagen.sprite = V90;
            }
            else if (vida == 8)
            {
                imagen.sprite = V80;
            }
            else if (vida == 7)
            {
                imagen.sprite = V70;
            }
            else if (vida == 6)
            {
                imagen.sprite = V60;
            }
            else if (vida == 5)
            {
                imagen.sprite = V50;
            }
            else if (vida == 4)
            {
                imagen.sprite = V40;
            }
            else if (vida == 3)
            {
                imagen.sprite = V30;
            }
            else if (vida == 2)
            {
                imagen.sprite = V20;
            }
            else if (vida == 1)
            {
                imagen.sprite = V10;
            }
            else if (vida == 0)
            {
                SceneManager.LoadScene("Muerte");
            }
            Source.PlayOneShot(Golpe);
        }
        if (vida <= 3 && CambioVidaBuffDisponible == true)
        {
            if (GameManager.VidaPorPrimaraVez == true)
            {
                puntoDeInstancia = new Vector2(Camara.x + RecuperarVidaBuff.transform.localScale.x / 2, Random.Range(0, Camara.y * 0.5f));
                Instantiate(RecuperarVidaBuff, puntoDeInstancia, Quaternion.identity);
            }
            else
            {
                NumeroAleatorioVidaBuff = Random.Range(0, 2);
                if (NumeroAleatorioVidaBuff == 1)
                {
                    puntoDeInstancia = new Vector2(Camara.x + RecuperarVidaBuff.transform.localScale.x / 2, Random.Range(0, Camara.y * 0.5f));
                    Instantiate(RecuperarVidaBuff, puntoDeInstancia, Quaternion.identity);
                }
            }
            CambioVidaBuffDisponible = false;
        }
        AvisoVidaEfecto();
    }
    public void RecuperarVida(int vidaASumar)
    {
        vida = vida + vidaASumar;
        if (vida > 10)
        {
            vida = 10;
        }
        if (vida == 10)
        {
            imagen.sprite = V100;
        }
        else if (vida == 9)
        {
            imagen.sprite = V90;
        }
        else if (vida == 8)
        {
            imagen.sprite = V80;
        }
        else if (vida == 7)
        {
            imagen.sprite = V70;
        }
        else if (vida == 6)
        {
            imagen.sprite = V60;
        }
        else if (vida == 5)
        {
            imagen.sprite = V50;
        }
        else if (vida == 4)
        {
            imagen.sprite = V40;
        }
        else if (vida == 3)
        {
            imagen.sprite = V30;
        }
        else if (vida == 2)
        {
            imagen.sprite = V20;
        }
        else if (vida == 1)
        {
            imagen.sprite = V10;
        }
        else if (vida == 0)
        {
            SceneManager.LoadScene("Muerte");
        }
        if(vida >= 4)
        {
            CambioVidaBuffDisponible = true;
        }
        AvisoVidaEfecto();


    }
    private void AvisoVidaEfecto()
    {
        if(vida > 5)
        {
            color.a = 0f;
        }
        else if (vida == 5)
        {
            color.a = 0.2f;
        }
        else if (vida == 4)
        {
            color.a = 0.3f;
        }
        else if (vida == 3)
        {
            color.a = 0.45f;
        }
        else if (vida == 2)
        {
            color.a = 0.6f;
        }
        else if (vida == 1)
        {
            color.a = 0.8f;
        }
        AvisoVida.color = color;
    }
}
