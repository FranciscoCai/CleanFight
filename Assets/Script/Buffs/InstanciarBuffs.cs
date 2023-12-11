using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarBuffs : MonoBehaviour
{
    [SerializeField] private float InstanciarDelay;
    private Vector3 Camara;
    [SerializeField] private GameObject BuffsCurar;
    private Vector2 puntoDeInstancia;
    void Start()
    {
        Camara = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -10));
        StartCoroutine(Instanciar());
    }
    void Update()
    {
        
    }
    private IEnumerator Instanciar()
    {
        while (true)
        {
            yield return new WaitForSeconds(InstanciarDelay);
            {
                LugarInstanciar();
            }
        }
    }
    private void LugarInstanciar()
    {
        puntoDeInstancia = new Vector2(Camara.x + BuffsCurar.transform.localScale.x/2, Random.Range(0, Camara.y * 0.5f));
        Instantiate(BuffsCurar, puntoDeInstancia,Quaternion.identity);
    }
    }
