using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Obstacle : FlyingObject
{
    public Texture[] textures;
    public Renderer renderer;
    // Use this for initialization
    void Start()
    {
        base.Start();
        int index = Random.Range(0, textures.Length);
        renderer.material.mainTexture = textures[index];
    }
}
