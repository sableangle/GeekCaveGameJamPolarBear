using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
public class AI_Player : MonoBehaviour
{
    public static bool isGameing = true;
    public static bool isFinish = false;


    Transform transformCache;
    public static int lifeInit = 300;
    public float life = 300;
    void Awake()
    {
        transformCache = transform;
        isGameing = true;
        finishTime = 60;
        isFinish = false;

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

        life = lifeInit;
        StartCoroutine(LifeLose());
        StartCoroutine( LevelProgress());
    }

    public float finishTime = 60;
    IEnumerator LevelProgress()
    {
        while (finishTime > 0)
        {
            finishTime -= Time.deltaTime;
            yield return null;
        }

        isFinish = true;
        yield return Yielders.GetWaitForSeconds(2f);
        // 獲勝 

        //生一隻企鵝
        var Pengun = Resources.Load("Pengun");

        Instantiate(Pengun, new Vector3(0, 4.9f, GameData.Instance.generateStartZ), Quaternion.identity);

        yield return Yielders.GetWaitForSeconds(0.5f);
        //UI
    }


    public float lifeLoseSpeed = 10;
    IEnumerator LifeLose()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                life += 50;
            }
            life -= Time.deltaTime * lifeLoseSpeed;
            if (life <= 0)
            {
                isGameing = false;
                UI_MainController.Instance.ShowGamerView();
                animator.SetTrigger("Dead");
                BGMSwitcher.Instance.PlayDeadBGM();
                SoundEffect.Instance.PlayLoseSound();
                StopAllCoroutines();
            }
            yield return null;
        }
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
        if (!isGameing)
        {
            return;
        }
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
            SoundEffect.Instance.PlayHitSound();
            life -= 60;

        }
        else if (collision.gameObject.tag == "Heart")
        {
            life += 30;
            life = Mathf.Clamp(life, 0, lifeInit);
            Destroy(collision.gameObject);
            SoundEffect.Instance.PlayAddSound();
        }
        else if (collision.gameObject.tag == "Hole")
        {
            collision.SendMessage("PlayAnimation");
        }
        else if (collision.gameObject.tag == "Win")
        {
            collision.gameObject.SendMessage("PengunEscape");
            isGameing = false;
        }
    }
}
