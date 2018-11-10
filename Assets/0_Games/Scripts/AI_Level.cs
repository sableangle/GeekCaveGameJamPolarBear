using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Level : MonoBehaviour
{
    public static AI_Level Instance;
    public ObjectPool rockPool;
    public ObjectPool fishPool;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(Level());
    }

    public void RecoveryFish(GameObject obj)
    {
        fishPool.Recovery(obj);
    }

    IEnumerator Level()
    {
        yield return Yielders.GetWaitForSeconds(Random.Range(0.5f, 1f));

        int key = Random.Range(0, 10);
        int position = Mathf.Clamp(Random.Range(-1, 2), -1, 1);
        if (key > 2)
        {

            rockPool.ReUse(new Vector3(position * GameData.Instance.moveXOffect, 0, GameData.Instance.generateStartZ), Quaternion.identity);
        }
        else
        {
            fishPool.ReUse(new Vector3(position * GameData.Instance.moveXOffect, 0, GameData.Instance.generateStartZ), Quaternion.identity);
        }
        yield return Level();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            rockPool.Recovery(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            fishPool.Recovery(collision.gameObject);
        }
    }
}
