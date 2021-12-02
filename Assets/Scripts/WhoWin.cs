using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhoWin : MonoBehaviour
{
    [SerializeField] private Text label;

    void Start()
    {
        if(SettingsButtonController.who == 2)
        {
            label.text = "妖狐陣営の勝ち！";
        }
        else if(SettingsButtonController.who == 1)
        {
            label.text = "人狼陣営の勝ち！";
        }
        else
        {
            label.text = "市民陣営の勝ち！";
        }
    }

    public void onClick()
    {
        SceneManager.LoadScene("Result");
    }
}
