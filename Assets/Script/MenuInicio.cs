using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{

    [SerializeField] private string escena;
    [SerializeField] private string menu;
    private bool Scene = false;

    public void Jugar()
    {
        SceneManager.LoadScene("VideoLore");
        

        if (Scene)
        {
            SceneManager.LoadScene("Juego");
        }
    }

    public void Volver()
    {
        SceneManager.LoadScene(menu);
    }
}
