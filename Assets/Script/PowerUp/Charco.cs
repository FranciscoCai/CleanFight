using System.Collections;
using UnityEngine;

public class Charco : MonoBehaviour
{
    [SerializeField] float duration = 5f;

    private void Start()
    {
        StartCoroutine(FadeAndShrinkCoroutine());
    }
    private IEnumerator FadeAndShrinkCoroutine()
    {
        float time = 0f;
        float startScale = transform.localScale.x;
        Color startColor = GetComponent<Renderer>().material.color;

        while (time < duration)
        {

            float scale = Mathf.Lerp(startScale, 0f, time / duration);
            transform.localScale = new Vector3(scale, scale, scale);


            Color color = GetComponent<Renderer>().material.color;
            color.a = Mathf.Lerp(startColor.a, 0f, time / duration);
            GetComponent<Renderer>().material.color = color;

            time += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
