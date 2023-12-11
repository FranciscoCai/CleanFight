using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivarCiempies : MonoBehaviour
{
    public float speed = 0.25f;
    [SerializeField] private GameObject Aviso;
    Color color;
    void Start()
    {
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        color = textMeshPro.color;
    }

    void Update()
    {
        color.a -= Time.deltaTime * speed;
        GetComponent<TextMeshProUGUI>().color = color;

        if (color.a + 2 <= 0)
        {
            Aviso.SetActive(true);
            Destroy(gameObject);
        }
    }
}
