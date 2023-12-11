using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtrasCreditos : MonoBehaviour
{

    [SerializeField] private string escenaACambiar;
    public void VolverInicio()
    {
        SceneManager.LoadScene(escenaACambiar);
    }
}
