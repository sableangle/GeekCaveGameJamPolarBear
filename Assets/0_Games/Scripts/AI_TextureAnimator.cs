using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_TextureAnimator : MonoBehaviour
{

    public Texture[] textures;
    Renderer renderer;
    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    void OnEnable()
    {
        StartCoroutine(playAnimatoin());
        playIndex = 0;
    }


    public int playIndex = 0;
    public float oneFrameWaitSec = 0.2f;
    IEnumerator playAnimatoin()
    {
        yield return Yielders.GetWaitForSeconds(oneFrameWaitSec);
        renderer.material.mainTexture = textures[playIndex % textures.Length];

        playIndex++;
        yield return playAnimatoin();
    }

}
