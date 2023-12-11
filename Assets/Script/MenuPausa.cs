using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] GameObject BotonPausa;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Camara;


    public void Pausa()
    {
        Camara.GetComponent<CambioMusica>().PararMusica();
        BotonPausa.SetActive(false);
        Menu.SetActive(true);
    }
    public void Empieza()
    {
        Camara.GetComponent<CambioMusica>().EmpezarMusica();
        Time.timeScale = 1f;
        BotonPausa.SetActive(true);
        Menu.SetActive(false);
    }
    public void ResetearEscena()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        SceneManager.LoadScene(indiceEscenaActual);
    }
    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
