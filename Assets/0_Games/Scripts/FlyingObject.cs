using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    Transform transformCache;
    public GameObject shadow;
    // Use this for initialization
    public void Start()
    {
        transformCache = transform;
    }
    public void OnEnable()
    {
        if (shadow) shadow.SetActive(true);

    }
    public void DisableShadow()
    {
        if (shadow) shadow.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (AI_Player.isGameing == false)
        {
            return;
        }
        transform.Translate(0, 0, -GameData.Instance.playerSpeed * Time.deltaTime, Space.World);
    }
}
