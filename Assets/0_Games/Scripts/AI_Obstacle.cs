using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AI_Obstacle : FlyingObject
{
    public Texture[] textures;
    public Renderer renderer;
    public GameObject shadow;
    // Use this for initialization
    void Start()
    {
        base.Start();
        int index = Random.Range(0, textures.Length);
    }

	void OnEnable(){
		shadow.SetActive(true);
	}

    public void DisableShadow()
    {
		shadow.SetActive(false);
    }
}
