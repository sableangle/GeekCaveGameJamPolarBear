using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AI_Obstacle : FlyingObject
{
    public Texture[] textures;
    public Renderer renderer;
   
    // Use this for initialization
    void Start()
    {
        base.Start();
        renderer = GetComponentInChildren<Renderer>();
    }

	void OnEnable(){
        int index = Random.Range(0, textures.Length);
        renderer.material.mainTexture = textures[index];
	}


}
