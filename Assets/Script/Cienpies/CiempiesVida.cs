using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CiempiesVida : MonoBehaviour
{
    [SerializeField]  private int vida = 20;
    private Image imagen;
    [SerializeField] private GameObject BarraDeVida;
    [SerializeField] private GameObject Fase2;
    [SerializeField] private GameObject BalaInvocar;
    [SerializeField] private Sprite V190;
    [SerializeField] private Sprite V180;
    [SerializeField] private Sprite V170;
    [SerializeField] private Sprite V160;
    [SerializeField] private Sprite V150;
    [SerializeField] private Sprite V140;
    [SerializeField] private Sprite V130;
    [SerializeField] private Sprite V120;
    [SerializeField] private Sprite V110;

    [SerializeField] Color targetColor;
    [SerializeField] float colorChangeDuration = 2f;
    [SerializeField] private AudioClip SonidoDisparo;
    private Color initialColor;
    private Renderer enemyRenderer;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
                vida = vida-2;
            }
            if (collision.gameObject.CompareTag("Chancla"))
            {
                vida = vida - 2;
            }

            if (vida == 18)
            {
                imagen.sprite = V190;
            }
            else if (vida == 16)
            {
                imagen.sprite = V180;
            }
            else if (vida == 14)
            {
                imagen.sprite = V170;
            }
            else if (vida == 12)
            {
                imagen.sprite = V160;
            }
            else if (vida == 10)
            {
                imagen.sprite = V150;
            }
            else if (vida == 8)
            {
                imagen.sprite = V140;
            }
            else if (vida == 6)
            {
                imagen.sprite = V130;
            }
            else if (vida == 4)
            {
                imagen.sprite = V120;
            }
            else if (vida == 2)
            {
                imagen.sprite = V110;
            }
            else if (vida <= 0)
            {
                if(gameObject.GetComponent<MovimientoCiempies>() != null)
                {
                    gameObject.GetComponent<MovimientoCiempies>().CiempiesMuerte = false;
                }
                rb.AddForce(Vector3.up * 15f, ForceMode2D.Impulse);
                Destroy(BarraDeVida);
                Destroy(BalaInvocar);
                Invoke("DespuesDeMuerte", 4f);
            }
            if(vida <= 7)
            {
                GameManager.RondaDelate = false;
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
    private void DespuesDeMuerte()
    {
        GameManager.RondaDelate = false;
        Fase2.SetActive(true);
        Destroy(gameObject);
    }
}
