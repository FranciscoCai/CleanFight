using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RondaAvispa : MonoBehaviour
{
    public float speed = 0.25f;
    Color color;
    [SerializeField] private GameObject Aviso;
    void Start()
    {
        GameManager.RondaDelate = false;
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
