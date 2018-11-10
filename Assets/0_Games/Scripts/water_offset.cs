using UnityEngine;
using System.Collections;

public class water_offset : MonoBehaviour
{
    public int materialIndex = 0;
    private Vector2 uvAnimationRate = new Vector2(0.0f, 0.0f);
    public string textureName = "_MainTex";
    float angle = 0;
    public float xx;
    public float yy;
    Vector2 uvOffset = Vector2.zero;
    Renderer renderer;
    void Start()
    {
        uvAnimationRate.x = xx;
        uvAnimationRate.y = yy;
        renderer = GetComponent<Renderer>();
    }

    void LateUpdate()
    {
        angle += 55f * 0.017444f * Time.deltaTime;
        uvOffset = 0.15f * uvAnimationRate * Mathf.Sin(angle);
        //uvOffset += new Vector2(0,-0.5f*Time.deltaTime);
        renderer.material.SetTextureOffset(textureName, uvOffset);
    }
}