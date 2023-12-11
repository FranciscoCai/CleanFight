using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class VidaCiempiesFase2 : MonoBehaviour
{
    public static VidaCiempiesFase2 instance { get; private set; }
    private Image imagen;
    [SerializeField] private GameObject Delay;
    [SerializeField] private int vida;
    [SerializeField] private Sprite V90;
    [SerializeField] private Sprite V80;
    [SerializeField] private Sprite V70;
    [SerializeField] private Sprite V60;
    [SerializeField] private Sprite V50;
    [SerializeField] private Sprite V40;
    [SerializeField] private Sprite V30;
    [SerializeField] private Sprite V20;
    [SerializeField] private Sprite V10;

    public void Start()
    {
        instance = this; 
        imagen = GetComponent<Image>();
    }
    public void Vida()
    {
        vida--;
        if (vida == 18)
        {
            imagen.sprite = V90;
        }
        else if (vida == 16)
        {
            imagen.sprite = V80;
        }
        else if (vida == 14)
        {
            imagen.sprite = V70;
        }
        else if (vida == 12)
        {
            imagen.sprite = V60;
        }
        else if (vida == 10)
        {
            imagen.sprite = V50;
        }
        else if (vida == 7)
        {
            imagen.sprite = V40;
        }
        else if (vida == 6)
        {
            imagen.sprite = V30;
        }
        else if (vida == 4)
        {
            imagen.sprite = V20;
        }
        else if (vida == 2)
        {
            imagen.sprite = V10;
        }
        else if (vida <= 0)
        {
            if (Delay != null)
            {
                Delay.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
