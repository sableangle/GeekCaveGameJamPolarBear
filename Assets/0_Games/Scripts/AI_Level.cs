using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Level : MonoBehaviour
{
    public ObjectPool rockPool;

    void Start()
    {
        StartCoroutine(Level());
    }

    IEnumerator Level()
    {
        yield return Yielders.GetWaitForSeconds(Random.Range(0.5f, 1f));
        int position = Mathf.Clamp(Random.Range(-1, 2), -1, 1);
        rockPool.ReUse(new Vector3(position * GameData.Instance.moveXOffect, 0, GameData.Instance.generateStartZ), Quaternion.identity);
        yield return Level();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            rockPool.Recovery(collision.gameObject);
        }

    }
}
