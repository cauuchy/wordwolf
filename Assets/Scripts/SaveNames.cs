using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveNames : MonoBehaviour
{
    private GameObject[] g;
    private InputField ipf;

    public void onClick()
    {
        g = GameObject.FindGameObjectsWithTag("PlayerTag");

        for (int i = 0; i < SettingsButtonController.total; i++)
        {
            ipf = g[i].GetComponent<InputField>();

            ScrollController.playerName[i] = ipf.text;
        }

        for(int i = SettingsButtonController.total; i < 20; i++)
        {
            ScrollController.playerName[i] = "プレイヤー" + (i + 1).ToString();
        }

        SceneManager.LoadScene("Settings");
    }
}