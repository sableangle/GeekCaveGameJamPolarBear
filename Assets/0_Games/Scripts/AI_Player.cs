using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
public class AI_Player : MonoBehaviour
{
    public static bool isGameing = true;


    Transform transformCache;

    public int life = 3;
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

        isGameing = true;
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

    public float maq = 0.5f;
    public float ShakeDuration = 0.4f;
    public float motion = 2;
    public Animator animator;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            collision.SendMessage("DisableShadow");
            collision.transform.DORotate(new Vector3(90, 0, 0), 0.05f);
            PerlinShaker.ShakePosition(Camera.main.transform, Vector3.one * maq, ShakeDuration, motion, false, false, Ease.OutElastic);
            UI_MainController.Instance.ShowHurtView();

            life -= 1;
            if (life <= 0)
            {
                isGameing = false;
                UI_MainController.Instance.ShowGamerView();
                animator.SetTrigger("Dead");
            }
        }
        else
        {
            life++;
            AI_Level.Instance.RecoveryFish(collision.gameObject);
        }

    }
}
