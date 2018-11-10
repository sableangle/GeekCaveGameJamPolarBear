using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
public class AI_Player : MonoBehaviour
{
    Transform transformCache;
    void Awake()
    {
        transformCache = transform;
    }
    void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.LeftArrow)).Subscribe(
                OnLeftKeyClick
            );

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(KeyCode.RightArrow)).Subscribe(
                OnRightKeyClick
            );
    }

    int playerPosition = 0;
    void OnLeftKeyClick(long click)
    {
        playerPosition--;
        playerPosition = Mathf.Clamp(playerPosition, -1, 1);
        MovePlayer();
    }

    void OnRightKeyClick(long click)
    {
        playerPosition++;
        playerPosition = Mathf.Clamp(playerPosition, -1, 1);
        MovePlayer();
    }

    float duration = 0.2f;
    void MovePlayer()
    {
        transformCache.DOMoveX(GameData.Instance.moveXOffect * playerPosition, duration);
    }


    void OnTriggerEnter(Collider collision)
    {
        collision.transform.DORotate(new Vector3(90, 0, 0), 0.05f);
        PerlinShaker.ShakePosition(Camera.main.transform, Vector3.one * 1.5f, 0.1f, 1, false);
    }
}
