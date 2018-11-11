using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AI_Hole : MonoBehaviour
{
    Transform transformCache;

    Renderer renderer;
    // Use this for initialization
    void Awake()
    {
        transformCache = transform;
        renderer = GetComponent<Renderer>();
    }

    void OnEnable()
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0);
    }

    public Animator animator;
    public void PlayAnimation()
    {
        animator.Play("Jump");
        if (animator.gameObject.name == "Uchi")
        {
            SoundEffect.Instance.PlayUchiSound();
        }
        else
        {
            SoundEffect.Instance.PlayFishJumpSound();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayAnimation();
        }
        renderer.material.color = new Color(
            renderer.material.color.r,
            renderer.material.color.g,
            renderer.material.color.b,
            1 - (transformCache.position.z / GameData.Instance.generateStartZ * 0.5f));
    }
}
