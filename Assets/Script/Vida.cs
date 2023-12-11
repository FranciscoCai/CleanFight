using System.Collections;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int vida;
    public int vidaActual;
    [SerializeField] int punto;
    [SerializeField] Color targetColor;
    [SerializeField] float colorChangeDuration = 2f;
    [SerializeField] private GameObject Muerte;
    [SerializeField] private AudioClip SonidoDisparo;
    private Color initialColor;
    private Renderer enemyRenderer;
    private bool estaSiendoDestruido = false;
    public bool AfectadoPorAgua = false;
    [SerializeField] private GameObject Particula;
    [SerializeField] private GameObject burbuja;
    void Update()
    {
        if (vida <= 0 && !estaSiendoDestruido)
        {
            StartCoroutine(DestruirConRetardo());
        }
    }

    private void Start()
    {
        vidaActual = vida;
        enemyRenderer = GetComponent<Renderer>();
        initialColor = enemyRenderer.material.color;
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bala"))
        {
            vida--;
            vidaActual = vida;
            Destroy(col.gameObject);
            StartCoroutine(ColorChangeCoroutine());
            SoundManager.instance.SonidoGolpe(SonidoDisparo);
            Instantiate(burbuja, col.gameObject.transform.position, Quaternion.identity);
        }
        if (col.gameObject.CompareTag("Chancla"))
        {
            vida = 0;
        }
        if (col.gameObject.CompareTag("BalaPower"))
        {
            vida = vida - 5;
            if (col.gameObject.GetComponent<Disparo>() != null)
            {
                col.gameObject.GetComponent<Disparo>().Invocar();
            }
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

    IEnumerator DestruirConRetardo()
    {
        estaSiendoDestruido = true;
        yield return new WaitForSeconds(0f);
        if (AfectadoPorAgua == true)
        {
            GameManager.instance.RecuperarVida(1);
        }
        GameManager.instance.Puntos(punto * 10);
        Instantiate(Muerte, transform.position, transform.rotation);
        Instantiate(Particula, transform.position, Quaternion.identity); 
        GameManager.instance.Delate();
        GameManager.RondaEjemplo = true;
        Destroy(gameObject);
        estaSiendoDestruido = false;
    }
}
