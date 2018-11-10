using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
	public float speed;
    Renderer renderer;
    float x;
    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime * GameData.Instance.playerSpeed * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(x, 0));
    }
}
