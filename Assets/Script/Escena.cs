using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena : MonoBehaviour
{

    public void Jugar()
    {

            SceneManager.LoadScene("Juego");


    }
    public void Volver()
    {
        SceneManager.LoadScene("Menu");
    }
}
