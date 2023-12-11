using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleDisparo : MonoBehaviour
{
    [SerializeField] private GameObject Charco;
    [SerializeField] private GameObject chancla;
    [SerializeField] private GameObject FuegoEfecto;
    [SerializeField] private GameObject AguaEfecto;
    [SerializeField] private GameObject ChanclaEfecto;
    public void Bala()
    {
        if (GameManager.PowerUpDobleDisponible == true && Time.timeScale != 0)
        {
            InstanciarBala.instance.PowerUp();
            GameManager.PowerUpDobleDisponible = false;
            GameManager.instance.CoolDownReset();
            FuegoEfecto.SetActive(false);
        }
    }
    public void Agua()
    {
        if (GameManager.PowerUpAgua == true && Time.timeScale != 0)
        {
            Instantiate(Charco);
            GameManager.instance.AguaPowerUp();
            GameManager.PowerUpAgua = false;
            GameManager.instance.CoolDownAguaRest();
            AguaEfecto.SetActive(false);
        }
    }
    public void Chancla()
    {
        if (GameManager.PowerUpChancla == true && Time.timeScale != 0)
        {
            Instantiate(chancla);
            GameManager.PowerUpChancla = false;
            GameManager.instance.CoolDownChanclaRest();
            ChanclaEfecto.SetActive(false); 
        }
    }

}
