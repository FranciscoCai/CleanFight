using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionParticulasDesaparecer : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player")) // Puedes cambiar "Player" al tag que tengas asignado a tu personaje
        {
            Destroy(gameObject); // Destruye el objeto que contiene el sistema de part¨ªculas
        }
    }
}
