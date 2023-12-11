using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChancla : MonoBehaviour
{
    public float destroyTime = 1f; 

    private void Start()
    {
        StartCoroutine(DestroyAfterTimeCoroutine());
    }

    private IEnumerator DestroyAfterTimeCoroutine()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
