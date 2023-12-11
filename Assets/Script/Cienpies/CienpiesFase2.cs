using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CienpiesFase2 : MonoBehaviour
{
    private Vector3 Camara;
    private float Shu;
    [SerializeField] private GameObject Enemigo;
    public static Ejemplo instance { get; private set; }
    private float RamdomNumber;
    [SerializeField] private float InvocarRapidez;
    private void Start()
    {
        Camara = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
        Shu = Camara.y;
        StartCoroutine(Instanciar());
    }
    private IEnumerator Instanciar()
    {
        while (true)
        {
            yield return new WaitForSeconds(InvocarRapidez);
            LugarInstanciar();
        }
    }
    private void LugarInstanciar()
    {
        RamdomNumber = Random.Range(-Camara.x + (Enemigo.transform.localScale.x / 2), Camara.x - (Enemigo.transform.localScale.x / 2));
        Instantiate(Enemigo, new Vector3(RamdomNumber, Shu, 0), Quaternion.identity);
    }
}
