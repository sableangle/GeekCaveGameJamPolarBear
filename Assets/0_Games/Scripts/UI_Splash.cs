using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Splash : MonoBehaviour
{

    public void OnLevelBtnClick(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game" + level);
    }
}
