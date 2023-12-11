using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDisparo : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 nuevaPosicion;
    void Start()
    {
      nuevaPosicion.y = gameObject.transform.position.y;
    }

    void Update()
    {
        nuevaPosicion.x = Player.transform.position.x;
        gameObject.transform.position = nuevaPosicion;
    }
}
