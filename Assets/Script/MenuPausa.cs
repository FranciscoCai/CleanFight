using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] GameObject BotonPausa;
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Camara;
    [SerializeField] GameObject Ajustes;


    public void Pausa()
    {
        Ajustes.SetActive(false);
        Camara.GetComponent<CambioMusica>().PararMusica();
        BotonPausa.SetActive(false);
        Menu.SetActive(true);
    }
    public void Empieza()
    {
        Ajustes.SetActive(true);
        Camara.GetComponent<CambioMusica>().EmpezarMusica();
        Time.timeScale = 1f;
        BotonPausa.SetActive(true);
        Menu.SetActive(false);
    }
    public void ResetearEscena()
    {
        Ajustes.SetActive(true);
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        SceneManager.LoadScene(indiceEscenaActual);
    }
    public void Exit()
    {
        Ajustes.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
