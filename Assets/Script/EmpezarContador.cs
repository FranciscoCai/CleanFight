using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EmpezarContador : MonoBehaviour
{
    public float speed = 0.25f;
    [SerializeField] private GameObject siguiente;
    [SerializeField] private float x;
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
        if (color.a + x <= 0)
        {
            siguiente.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
