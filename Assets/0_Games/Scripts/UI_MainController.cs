using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UI_MainController : MonoBehaviour
{
    public static UI_MainController Instance;
    void Awake()
    {
        Instance = this;
    }


    // Use this for initialization
    void Start()
    {
        Hurt.alpha = 0;
        GameOverPanel.alpha = 0;
    }
    public CanvasGroup Hurt;
    Sequence hurtSeq;
    public void ShowHurtView()
    {
        if (hurtSeq != null)
        {
            hurtSeq.Kill();
        }
        hurtSeq = DOTween.Sequence();
        hurtSeq.Join(Hurt.DOFade(1, 0.2f))
            .Append(Hurt.DOFade(0, 0.2f));
    }


    public CanvasGroup GameOverPanel;
    public Tween GameOver;
    public Text gameOverMsgText;
    string[] gameOverMsg = new string[]{
        "北極熊因全球暖化而導致數量銳減，全世界的北極熊僅剩25000隻",
        "冰山融化使得北極熊不易覓食捕獵，母熊因而缺乏乳汁，導致熊寶寶餓死。",
        "科學家認為，若全球暖化速率不減，在本世紀中，北極熊的數量會銳減2/3",
        "受海洋污染影響，北極熊的食物充滿毒素，過多的毒素將導致內臟衰竭死亡",
    };
    public void ShowGamerView()
    {
        if (GameOver != null)
        {
            GameOver.Kill();
        }
        gameOverMsgText.text = gameOverMsg[Random.Range(0, gameOverMsg.Length)];
        GameOverPanel.DOFade(1, 0.4f).SetDelay(0.5f);
    }
    public void OnGameOverAgainClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Application.loadedLevelName);
    }
    public void OnGameOverExitClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hello");
    }
}
