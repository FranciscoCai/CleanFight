using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deslizar : MonoBehaviour
{

    private Vector3 touchPosition;
    private Vector3 worldPosition;
    private Vector3 PosicionInicial;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorBoton;

    private void Awake()
    {
        PosicionInicial = player.gameObject.transform.position;
    }
    void Update()
    {
        if (Input.touchCount > 0 && Time.timeScale != 0)
        {
            animator.SetBool("Disparo", true);
            animatorBoton.SetBool("Pulsado", true);
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                touchPosition = Input.GetTouch(0).position;
                worldPosition =Camera.main.ScreenToWorldPoint(touchPosition);
                player.gameObject.transform.position = new Vector3(worldPosition.x, PosicionInicial.y, worldPosition.z + 10);

            }
        }
        else
        {
            animatorBoton.SetBool("Pulsado", false);
            animator.SetBool("Disparo", false) ;
        }
    }
}
