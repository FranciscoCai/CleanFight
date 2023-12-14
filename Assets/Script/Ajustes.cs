using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ajustes : MonoBehaviour
{
    [SerializeField] private GameObject Icon;
    [SerializeField] private GameObject Musics;
    public void EntrarAjustes()
    {
        Time.timeScale = 0f;
        Icon.SetActive(false);
        Musics.SetActive(true);
    }
    public void  SalirAjustes()
    {
        Time.timeScale = 1f;
        Icon.SetActive(true );
        Musics.SetActive(false);
    }
    public void OpenPrivacy()
    {
        Application.OpenURL("https://tlspro.com/privacy-policy");
    }
}
