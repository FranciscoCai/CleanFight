using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    [SerializeField] float transparenciaInicial = 1f;
    [SerializeField] float transparenciaFinal = 0f;
    private void Update()
    {
        Material material = GetComponent<Renderer>().material;

        Color colorActual = material.color;
        Color colorTransparente = new Color(colorActual.r, colorActual.g, colorActual.b, transparenciaFinal);
        Color colorInterpolado = Color.Lerp(colorActual, colorTransparente, Time.deltaTime);
        material.color = colorInterpolado;
        Invoke("Destruir", 2.5f);
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }
}
