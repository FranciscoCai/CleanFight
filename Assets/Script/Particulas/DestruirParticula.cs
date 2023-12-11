using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirParticula : MonoBehaviour
{  
    private ParticleSystem particleSystem;
    private bool delay = false;
    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    private void OnDestroy()
    {
        GameManager.instance.CoolDown(1);
        GameManager.instance.CoolDownAgua(1);
        GameManager.instance.CoolDownChancla(1);
    }
    private void Update()
    {
        if (particleSystem.particleCount > 0)
        {
            delay = true;
        }
        if (particleSystem.particleCount == 0 && delay == true)
        {
            Destroy(gameObject);
        }
    }


}
