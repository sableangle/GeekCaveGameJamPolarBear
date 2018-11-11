using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AI_Storm : MonoBehaviour
{
    public Renderer stormmaterial;
    public GameObject particle;

    float alpha = 0;
    public float speed = 2;

    // Use this for initialization
    IEnumerator Start()
    {
        alpha = 0;
        stormmaterial.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alpha));
        yield return Yielders.GetWaitForSeconds(Random.Range(8, 15));
        particle.SetActive(true);
        alpha = 0.0001f;
        while (alpha > 0)
        {
            alpha += Time.deltaTime * speed;
            stormmaterial.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alpha));

            if (AI_Player.isFinish == true)
            {
                alpha = 0;
                stormmaterial.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, alpha));

                yield break;
            }
            yield return null;
        }

        particle.SetActive(false);

        yield return Start();

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            alpha -= Time.deltaTime * speed * 1.5f;

        }
    }


}
