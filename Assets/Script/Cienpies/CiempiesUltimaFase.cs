using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CiempiesUltimaFase : MonoBehaviour
{
    [SerializeField] private int vida = 20;
    private Image imagen;
    [SerializeField] private GameObject BarraDeVida;
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
    private int GanarGuardado;
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

            if (vida == 19)
            {
                imagen.sprite = V190;
            }
            else if (vida == 18)
            {
                imagen.sprite = V180;
            }
            else if (vida == 17)
            {
                imagen.sprite = V170;
            }
            else if (vida == 16)
            {
                imagen.sprite = V160;
            }
            else if (vida == 15)
            {
                imagen.sprite = V150;
            }
            else if (vida == 14)
            {
                imagen.sprite = V140;
            }
            else if (vida == 13)
            {
                imagen.sprite = V130;
            }
            else if (vida == 12)
            {
                imagen.sprite = V120;
            }
            else if (vida == 11)
            {
                imagen.sprite = V110;
            }
            else if (vida == 10)
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
            else if (vida <= 0)
            {
                GanarGuardado = PlayerPrefs.GetInt("CreditosBool");
                if (GanarGuardado == 1)
                { 
                    SceneManager.LoadScene("VideoCredito");
                }
                else if(GanarGuardado == 0)
                {
                    GanarGuardado = 1;
                    PlayerPrefs.SetInt("CreditosBool", GanarGuardado);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Creditos");
                }

                
                Destroy(gameObject);
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
}
