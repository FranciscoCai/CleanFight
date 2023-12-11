using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaAvispa : MonoBehaviour
{
    [SerializeField] private int vida = 20;
    private Image imagen;
    [SerializeField] private GameObject BarraDeVida;
    [SerializeField] private GameObject Ronda9;
    [SerializeField] private Sprite V200;
    [SerializeField] private Sprite V190;
    [SerializeField] private Sprite V180;
    [SerializeField] private Sprite V170;
    [SerializeField] private Sprite V160;
    [SerializeField] private Sprite V150;
    [SerializeField] private Sprite V140;
    [SerializeField] private Sprite V130;
    [SerializeField] private Sprite V120;
    [SerializeField] private Sprite V110;
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
    [SerializeField] Color targetColor;
    [SerializeField] float colorChangeDuration = 2f;
    [SerializeField] private AudioClip SonidoDisparo;
    private Color initialColor;
    private Renderer enemyRenderer;
    [SerializeField] private GameObject Camara;
    [SerializeField] private GameObject punto1;
    [SerializeField] private GameObject punto2;

    private bool x1 = true;
    private bool x2 = true;

    private void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
        imagen = BarraDeVida.GetComponent<Image>();
        initialColor = enemyRenderer.material.color;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bala") || collision.gameObject.CompareTag("BalaPower") || collision.gameObject.CompareTag("Chancla"))
        {
            if (collision.gameObject.CompareTag("Bala"))
            {
                SoundManager.instance.SonidoGolpe(SonidoDisparo);
                vida--;
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("BalaPower"))
            {
                if (collision.gameObject.GetComponent<Disparo>() != null)
                {
                    collision.gameObject.GetComponent<Disparo>().Invocar();
                }
                vida = vida - 2;
            }
            if (collision.gameObject.CompareTag("Chancla"))
            {
                vida = vida - 2;
            }
            if (vida == 40)
            {
                imagen.sprite = V200;
            }
            else if (vida == 38)
            {
                imagen.sprite = V190;
            }
            else if (vida == 36)
            {
                imagen.sprite = V180;
            }
            else if (vida == 34)
            {
                imagen.sprite = V170;
            }
            else if (vida == 32)
            {
                imagen.sprite = V160;
            }
            else if (vida == 30)
            {
                imagen.sprite = V150;
            }
            else if (vida == 28)
            {
                imagen.sprite = V140;
            }
            else if (vida == 26)
            {
                imagen.sprite = V130;
            }
            else if (vida == 24)
            {
                imagen.sprite = V120;
            }
            else if (vida == 22)
            {
                imagen.sprite = V110;
            }
            else if (vida == 20)
            {
                imagen.sprite = V100;
            }
            else if (vida == 18)
            {
                imagen.sprite = V90;
            }
            else if (vida == 16)
            {
                imagen.sprite = V80;
            }
            else if (vida == 14)
            {
                imagen.sprite = V70;
            }
            else if (vida == 12)
            {
                imagen.sprite = V60;
            }
            else if (vida == 10)
            {
                imagen.sprite = V50;
            }
            else if (vida == 8)
            {
                imagen.sprite = V40;
            }
            else if (vida == 6)
            {
                imagen.sprite = V30;
            }
            else if (vida == 4)
            {
                imagen.sprite = V20;
            }
            else if (vida == 2)
            {
                imagen.sprite = V10;
            }
            else if (vida <= 0)
            {
                Destroy(BarraDeVida);
                Ronda9.SetActive(true);
                Camara.GetComponent<CambioMusica>().musicaInicial();
                Destroy(gameObject);
            }
            if (vida <= 25)
            {
                if (x1 == true)
                {
                    gameObject.GetComponent<AvispaFlip>().Fase1();
                    x1 = false;
                    StartCoroutine(Bajar1());
                }
            }
            if (vida <= 15)
            {
                if (x2 == true)
                {
                    gameObject.GetComponent<AvispaFlip>().Fase2();
                    x2 = false;
                    StartCoroutine(Bajar2());
                }
            }
            StartCoroutine(ColorChangeCoroutine());
        }
    }
    private IEnumerator ColorChangeCoroutine()
    {
        float time = 0f;
        while (time < colorChangeDuration)
        {
            Color newColor = Color.Lerp(initialColor, targetColor, time / colorChangeDuration);
            enemyRenderer.material.color = newColor;

            time += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(colorChangeDuration);
        enemyRenderer.material.color = initialColor;
    }
    private IEnumerator Bajar1()
    {
        while (gameObject.transform.localPosition.y > punto1.transform.localPosition.y)
        {
            gameObject.GetComponent<AvispaFlip>().movimiento.y = -3;
            yield return null;
        }
        gameObject.GetComponent<AvispaFlip>().movimiento.y = 0;
    }
    private IEnumerator Bajar2()
    {
        while (gameObject.transform.localPosition.y > punto2.transform.localPosition.y)
        {
            gameObject.GetComponent<AvispaFlip>().movimiento.y = -3;
            yield return null;
        }
        gameObject.GetComponent<AvispaFlip>().movimiento.y = 0;
    }
}
