using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AI_Pengun : FlyingObject
{


    public Texture pengunback;
    // Update is called once per frame
    public void PengunEscape()
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = pengunback;
        transform.DOMoveZ(300, 1).SetEase(Ease.Linear).OnComplete(
            () =>
            {
                UI_MainController.Instance.ShowWinView();

            }
        );
    }
}
