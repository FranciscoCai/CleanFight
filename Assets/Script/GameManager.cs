using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int PuntosCompartidos { get { return puntos; } }
    public int CD { get { return cd; }}
    public int CDA { get { return cda; } }
    public int CCD { get { return ccd; } }
    public static GameManager instance { get; private set; }
    private int puntos;
    private Vector3 vectorInicial = new Vector3(0, 0, 0);
    public int cd;
    public int cda;
    public int ccd;
    public int HabilidadStart;
    [SerializeField] private Color myColor;
    public int NumeroDeEnemigoInvocado;
    [SerializeField] private int RondaInvoar;
    [SerializeField] private GameObject HabilidadOscuridadF;
    [SerializeField] private GameObject HabilidadOscuridadA;
    [SerializeField] private GameObject HabilidadOscuridadC;
    [SerializeField] private GameObject round2;
    [SerializeField] private GameObject round3;
    [SerializeField] private GameObject round4;
    [SerializeField] private GameObject round5;
    [SerializeField] private GameObject round6;
    [SerializeField] private GameObject round7;
    [SerializeField] private GameObject round8;
    [SerializeField] private GameObject round9;
    [SerializeField] private GameObject round10;
    [SerializeField] private GameObject round11;
    [SerializeField] private GameObject BarraDeVida;
    private Movimiento enemyMovement;
    private MovimientoCiempies ciempiesMovement;
    private AvispaFlip avispaMovement;
    [SerializeField] private GameObject OscuroCd;
    [SerializeField] private GameObject OscuroCcd;
    [SerializeField] private GameObject OscuroCda;
    private Image OscuroCdImagen;
    private Image OscuroCcdImagen;
    private Image OscuroCdaImagen;
    [SerializeField] private AudioClip Fuego;
    [SerializeField] private AudioClip Agua;
    [SerializeField] private AudioClip Chancla;
    public static bool VidaPorPrimaraVez;
    [SerializeField] private GameObject FuegoP;
    [SerializeField] private GameObject AguaP;
    [SerializeField] private GameObject ChanclaP;
    private ParticleSystem FuegoParticula;
    private ParticleSystem AguaParticula;
    private ParticleSystem ChanclaParticula;
    [SerializeField] private GameObject FuegoEfecto;
    [SerializeField] private GameObject AguaEfecto;
    [SerializeField] private GameObject ChanclaEfecto;
    public int EnemigoDerrotado;
    public bool x;
    private void Update()
    {
    }

    public void Awake()
    {
        instance = this;
        PowerUpDobleDisponible = true;
        PowerUpAgua = true;
        PowerUpChancla = true;
        RondaDelate = true;
        RondaEjemplo = true;
        VidaPorPrimaraVez = false;
        HabilidadStart = 0;
        OscuroCdImagen = OscuroCd.GetComponent<Image>();
        OscuroCcdImagen = OscuroCcd.GetComponent<Image>();
        OscuroCdaImagen = OscuroCda.GetComponent<Image>();
        FuegoParticula = FuegoP.GetComponent<ParticleSystem>();
        AguaParticula = AguaP.GetComponent<ParticleSystem>();
        ChanclaParticula = ChanclaP.GetComponent<ParticleSystem>();
    }
    public void Puntos(int Sumar)
    {
        puntos += Sumar;
        MostrarPuntos.instance.PuntosCanvas();
    }
    public void CoolDown(int Puntos)
    {
        if (cd > 0)
        {
            cd -= Puntos;
            if (cd < 0)
            {
                cd = 0;
            }
            if (cd == 0)
            {
                PowerUpDobleDisponible = true;
                HabilidadOscuridadF.SetActive(false);
                SoundManager.instance.ReproducirSonido(Fuego);
                FuegoEfecto.SetActive(true);
                FuegoParticula.Play();
            }
            MostrarOscuroCd();
            MostrarPuntos.instance.PWCD();
        }
    }
    public void CoolDownReset()
    {
        cd = 10;
        HabilidadOscuridadF.SetActive(true);
        MostrarOscuroCd();
        MostrarPuntos.instance.PWCD();
    }
    public void CoolDownAgua(int Puntos)
    {
        if (cda > 0)
        {
            cda -= Puntos;
            if (cda < 0)
            {
                cda = 0;
            }
            if (cda == 0)
            {
                PowerUpAgua = true;
                HabilidadOscuridadA.SetActive(false);
                SoundManager.instance.ReproducirSonido(Agua);
                AguaEfecto.SetActive(true);
                AguaParticula.Play();
            }
            MostrarOscuroCda();
            MostrarPuntos.instance.PWACD();
        }
    }
    public void CoolDownAguaRest()
    {
        cda = 15;
        HabilidadOscuridadA.SetActive(true);
        MostrarOscuroCda();
        MostrarPuntos.instance.PWACD();
    }
    public void CoolDownChancla(int Puntos)
    {
        if (ccd > 0)
        {
            ccd -= Puntos;
            if (ccd < 0)
            {
                ccd = 0;
            }
            if (ccd == 0)
            {
                PowerUpChancla = true;
                HabilidadOscuridadC.SetActive(false);
                SoundManager.instance.ReproducirSonido(Chancla);
                ChanclaEfecto.SetActive(true);
                ChanclaParticula.Play();
            }
            MostrarOscuroCcd();
            MostrarPuntos.instance.PWCCD();
        }
    }
    public void CoolDownChanclaRest()
    {
        ccd = 20;
        HabilidadOscuridadC.SetActive(true);
        MostrarOscuroCcd();
        MostrarPuntos.instance.PWCCD();
    }
    public static bool PowerUpAgua;
    public static bool PowerUpDobleDisponible;
    public static bool PowerUpChancla;
    public static bool RondaDelate;
    public static bool RondaEjemplo;

    public void AguaPowerUp()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemyMovement = enemy.GetComponent<Movimiento>();
            ciempiesMovement = enemy.GetComponent<MovimientoCiempies>();
            avispaMovement = enemy.GetComponent <AvispaFlip>();
            if (enemyMovement != null)
            {
                enemy.GetComponent<SpriteRenderer>().color = Color.blue;
                enemyMovement.movimiento /= 2;
                if (enemy.GetComponent<Vida>() != null)
                {
                    Vida enemyVida = enemy.GetComponent<Vida>();
                    enemyVida.vida = 1;
                    enemyVida.AfectadoPorAgua = true;
                    Animator enemigoAnimacion = enemy.GetComponent<Animator>();
                    enemigoAnimacion.speed = 0.5f;
                }
            }
            else if(ciempiesMovement != null)
            {
                ciempiesMovement.GetComponent<SpriteRenderer>().color = myColor;
                ciempiesMovement.movimiento /= 2;
                MovimientoCiempies.instance.velocidad();
                Animator enemigoAnimacion = enemy.GetComponent<Animator>();
                enemigoAnimacion.speed = 0.5f;
            }
            else if (avispaMovement != null)
            {
                avispaMovement.GetComponent<SpriteRenderer>().color = myColor;
                avispaMovement.movimiento.x /= 2;
                AvispaFlip.instance.velocidad();
                Animator enemigoAnimacion = enemy.GetComponent<Animator>();
                enemigoAnimacion.speed = 0.5f;
            }
            StartCoroutine(ResetSpeedAfterDelay());
        }
    }
    IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(5);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
             enemyMovement = enemy.GetComponent<Movimiento>();
             ciempiesMovement = enemy.GetComponent<MovimientoCiempies>();
             avispaMovement = enemy.GetComponent<AvispaFlip>();
            if (enemyMovement != null)
            {
                if (enemy.GetComponent<Vida>() != null)
                {
                    Vida enemyVida = enemy.GetComponent<Vida>();
                    enemyVida.vida = enemyVida.vidaActual;
                    enemyVida.AfectadoPorAgua = false;
                    Animator enemigoAnimacion = enemy.GetComponent<Animator>();
                    enemigoAnimacion.speed = 1f;
                }
                enemy.GetComponent<SpriteRenderer>().color = Color.white;
                enemyMovement.movimiento = enemyMovement.VelocidadInicial;
            }
            else if (ciempiesMovement != null)
            {
                ciempiesMovement.GetComponent<SpriteRenderer>().color = Color.white;
                ciempiesMovement.movimiento = ciempiesMovement.VelocidadInicial;
                MovimientoCiempies.instance.velocidad();
                Animator enemigoAnimacion = enemy.GetComponent<Animator>();
                enemigoAnimacion.speed = 1f;
            }
            else if(avispaMovement != null)
            {
                avispaMovement.GetComponent<SpriteRenderer>().color = Color.white;
                avispaMovement.movimiento.x = avispaMovement.movimiento.x *= 2; 
                AvispaFlip.instance.velocidad();
                Animator enemigoAnimacion = enemy.GetComponent<Animator>();
                enemigoAnimacion.speed = 1f;
            }
        }
    }
    public void Contador()
    {
        NumeroDeEnemigoInvocado++;
        if (NumeroDeEnemigoInvocado == 10)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 20)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 35)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 55)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 63)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 72)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 77)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 83)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 91)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 100)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 110)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 120)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 130)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 140)
        {
            RondaDelate = x;
        }
        if (NumeroDeEnemigoInvocado == 150)
        {
            RondaDelate = x;
        }
    }
    public void Delate()
    {
        EnemigoDerrotado++;
        if (EnemigoDerrotado == NumeroDeEnemigoInvocado && RondaDelate == false)
        {
            if (RondaInvoar == 2)
            {
                round2.SetActive(true);
            }
            if (RondaInvoar == 3)
            {
                round3.SetActive(true);
            }
            if (RondaInvoar == 4)
            {
                round4.SetActive(true);
            }
            if (RondaInvoar == 5)
            {
                round5.SetActive(true);
            }
            if (RondaInvoar == 6)
            {
                RondaDelate = true;
            }
            if (RondaInvoar == 7)
            {
                round6.SetActive(true);
            }
            if (RondaInvoar == 8)
            {
                RondaDelate = true;
            }
            if (RondaInvoar == 9)
            {
                round7.SetActive(true);
            }
            if (RondaInvoar == 10)
            {
                RondaDelate = true;
            }
            if (RondaInvoar == 11)
            {
                round8.SetActive(true);
            }
            if (RondaInvoar == 12)
            {
                RondaDelate = true;
            }
            if (RondaInvoar == 13)
            {
                round10.SetActive(true);
            }
            if (RondaInvoar == 14)
            {
                RondaDelate = true;
            }
            if (RondaInvoar == 15)
            {
                RondaDelate = true;
            }
            if (RondaInvoar == 16)
            {
                RondaDelate = false;
                round11.SetActive(true);
            }
            RondaInvoar++;
        }
    }
    public void RecuperarVida(int vidaASumar)
    {
        BarraDeVida.GetComponent<RestarVida>().RecuperarVida(vidaASumar);
    }

    public void CambioVelocidad(GameObject enemigo, float velocidadACambiar)
    {
        enemigo.GetComponent<Movimiento>().movimiento.y = velocidadACambiar;
    }

    public void MostrarOscuroCd()
    {
        OscuroCdImagen.fillAmount = (float)cd/10;
    }
    public void MostrarOscuroCcd()
    {
        OscuroCcdImagen.fillAmount = (float)ccd / 20;
    }
    public void MostrarOscuroCda()
    {
        OscuroCdaImagen.fillAmount = (float)cda / 15;
    }
}
