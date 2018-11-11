using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Level : MonoBehaviour
{
    public static AI_Level Instance;
    public GameObject rockPool;
    public GameObject fishPool;
    public GameObject HoldFish;
    public GameObject HoldUchi;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(Level());
    }


    IEnumerator Level()
    {
        if(!AI_Player.isGameing){
            yield break;
        }
        yield return Yielders.GetWaitForSeconds(Random.Range(0.25f, 0.5f));

        int key = Random.Range(0, 10);
        int position = Mathf.Clamp(Random.Range(-1, 2), -1, 1);
        if (key > 2)
        {

            Instantiate(rockPool,new Vector3(position * GameData.Instance.moveXOffect, 0, GameData.Instance.generateStartZ), Quaternion.identity);
        }
        else if (key == 0)
        {
            Instantiate(fishPool,new Vector3(position * GameData.Instance.moveXOffect, 0, GameData.Instance.generateStartZ), Quaternion.identity);
        }
        else if (key == 1)
        {
            Instantiate(HoldFish, new Vector3(position * GameData.Instance.moveXOffect, 0.2f, GameData.Instance.generateStartZ), Quaternion.Euler(90,0,0));
        }
        else if (key == 2)
        {
            Instantiate(HoldUchi, new Vector3(position * GameData.Instance.moveXOffect, 0.2f, GameData.Instance.generateStartZ), Quaternion.Euler(90,0,0));
        }
        yield return Level();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Heart")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Hole")
        {
            Destroy(collision.gameObject);
        }
    }
}
