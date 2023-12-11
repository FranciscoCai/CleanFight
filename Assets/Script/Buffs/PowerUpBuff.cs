using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBuff : MonoBehaviour
{
    private bool x = true;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bala") || col.gameObject.CompareTag("Chancla") || col.gameObject.CompareTag("BalaPower"))
        {
            if (col.gameObject.CompareTag("Bala"))
            {
                BarraDeVidaCambio();
                Destroy(col.gameObject);
            }
            if (col.gameObject.CompareTag("Chancla"))
            {
                BarraDeVidaCambio();
            }
            if (col.gameObject.CompareTag("BalaPower"))
            {
                if (col.gameObject.GetComponent<Disparo>() != null)
                {
                    col.gameObject.GetComponent<Disparo>().Invocar();
                    BarraDeVidaCambio();
                    Destroy(col.gameObject);
                }
            }


        }
    }
    private void BarraDeVidaCambio()
    {
        if (x == true)
        {
            x = false;
            GameManager.instance.CoolDown(20);
            GameManager.instance.CoolDownAgua(20);
            GameManager.instance.CoolDownChancla(20);
        }
        Destroy(gameObject);
    }
}
