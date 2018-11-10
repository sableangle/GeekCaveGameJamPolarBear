using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    Transform transformCache;
    // Use this for initialization
    void Start()
    {
        transformCache = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -GameData.Instance.playerSpeed * Time.deltaTime,Space.World);
    }
}
