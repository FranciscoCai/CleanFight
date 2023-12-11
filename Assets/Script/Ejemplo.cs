using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejemplo : MonoBehaviour
{
    private Vector3 Camara;
    private float Shu;
    [SerializeField] private GameObject Cucaracha;
    [SerializeField] private GameObject Arana;
    [SerializeField] private GameObject Mosca;
    [SerializeField] private GameObject Mosquito;
    [SerializeField] private GameObject Moho;
    private GameObject Enemigo;
    public float numero;
    public static Ejemplo instance { get; private set; }
    private float RamdomNumber;
    private float EnemigoEjemplo = 2;
    public float numeroMinimo = 0f;
    public float InstanciarDelay = 0.5f;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {    
        Camara = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
        Shu = Camara.y;
        StartCoroutine(Instanciar());
        Enemigo = Cucaracha;
    }
    private IEnumerator Instanciar()
    {
        while (true)
        {
            yield return new WaitForSeconds(InstanciarDelay);
            if (GameManager.RondaDelate == true && GameManager.RondaEjemplo == true)
            {
                LugarInstanciar();
            }
        }
    }
    private void LugarInstanciar()
    {

        float randomNumber = Random.Range(numeroMinimo, numero) ;
        if (randomNumber <= 0.25f)
        {
            Enemigo = Moho;
        }
        else if (randomNumber <= 0.5f)
        {
            Enemigo = Mosca;
        }
        else if (randomNumber <= 0.75f)
        {
            Enemigo = Mosquito;
        }
        else if (randomNumber <= 1f)
        {
            Enemigo = Cucaracha;
        }
        else if(randomNumber <= 1.25f)
        {
            Enemigo = Arana;
        }
        RamdomNumber = Random.Range(-Camara.x + (gameObject.transform.localScale.x / 2), Camara.x - (gameObject.transform.localScale.x / 2));
        Instantiate(Enemigo, new Vector3(RamdomNumber, Shu,0), Quaternion.identity);
        GameManager.instance.Contador();
    }
    public void NuevaRonda(float ronda)
    {
        numero = numero + ronda;
    }
    public void NuevaRondaEjemplo(GameObject Enemigo)
    {
        if(EnemigoEjemplo == 2) 
        {
            Enemigo = Mosca;
        }
        if (EnemigoEjemplo == 3)
        {
            Enemigo = Mosquito;
        }
        if (EnemigoEjemplo == 4)
        {
            Enemigo = Cucaracha;
        }
        if (EnemigoEjemplo == 5)
        {
            Enemigo = Arana;
        }
        RamdomNumber = Random.Range(-Camara.x + (gameObject.transform.localScale.x / 2), Camara.x - (gameObject.transform.localScale.x / 2));
        Instantiate(Enemigo, new Vector3(RamdomNumber, Shu, 0), Quaternion.identity);
        GameManager.instance.NumeroDeEnemigoInvocado++;
        EnemigoEjemplo++;
    }

    public void CambiarInstanciar(float x)
    {
        InstanciarDelay = InstanciarDelay + x;
    }
}
