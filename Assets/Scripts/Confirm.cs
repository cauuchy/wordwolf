using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System;

public class Confirm : MonoBehaviour
{
    [SerializeField] private GameObject warnText, wordText, confirmButton, okButton, nextButton, gmText, popOut;
    [SerializeField] private Text label, endlabel, wordlabel;
    List<string[]> csvDatas = new List<string[]>();
    static public List<int> roles = new List<int>();
    private TextAsset csvFile;
    private int count = 0;
    private int playerNum = 0;
    private int height;
    static public string villager;
    static public string wolf;
    static public string fox;

    void Start()
    {

        label.text = ScrollController.playerName[0] + "\nはお題を確認してください";

        popOut.SetActive(false);
        warnText.SetActive(true);
        wordText.SetActive(false);
        confirmButton.SetActive(true);
        okButton.SetActive(false);
        nextButton.SetActive(false);
        gmText.SetActive(false);

        rolesAdd();

        if(SettingsButtonController.gmMode
            && GMInput.vtxt != ""
            && GMInput.wtxt != ""
            && GMInput.ftxt != "")
        {
            villager = GMInput.vtxt;
            wolf = GMInput.wtxt;
            fox = GMInput.ftxt;
        }
        else
        {
            csvread();

            int n = UnityEngine.Random.Range(0, height);

            villager = csvDatas[n][0];
            wolf = csvDatas[n][1];
            fox = csvDatas[n][2];
        }

        roles = roles.OrderBy(a => Guid.NewGuid()).ToList();
    }

    public void popOutClick()
    {
        popOut.SetActive(true);
    }

    public void popOutCancel()
    {
        popOut.SetActive(false);
    }

    public void btClick1()
    {
        switch (roles[count])
        {
            case 0:
                wordlabel.text = "あなたのお題は\n「" + villager + "」\nです";
                break;
            case 1:
                wordlabel.text = "あなたのお題は\n「" + wolf + "」\nです";
                break;
            case 2:
                wordlabel.text = "あなたのお題は\n「" + fox + "」\nです";
                break;
        }
        warnText.SetActive(false);
        wordText.SetActive(true);
        confirmButton.SetActive(false);
        okButton.SetActive(true);
        count++;
        if (count >= SettingsButtonController.total) return;
    }

    public void btClick2()
    {
        wordText.SetActive(false);
        okButton.SetActive(false);
        nextButton.SetActive(true);
        if(playerNum == SettingsButtonController.total - 1 && SettingsButtonController.gmMode) {
            label.text = "ゲームマスターは\nゲームを開始してください";
            gmText.SetActive(true);
        }
    }

    public void btClick3()
    {
        playerNum++;
        if (playerNum < SettingsButtonController.total)
        {
            label.text = ScrollController.playerName[playerNum] + "\nはお題を確認してください";
            warnText.SetActive(true);
            wordText.SetActive(false);
            confirmButton.SetActive(true);
            okButton.SetActive(false);
            nextButton.SetActive(false);
            if (playerNum == SettingsButtonController.total - 1) {
                endlabel.text = "ゲーム開始";
            }
        }
        else
        {
            SceneManager.LoadScene("TalkTime");
        }
    }

    void rolesAdd()
    {
        roles.Clear();

        for (int i = 0; i < SettingsButtonController.vnum; i++)
        {
            roles.Add(0);
        }

        for (int i = 0; i < SettingsButtonController.wnum; i++)
        {
            roles.Add(1);
        }

        for (int i = 0; i < SettingsButtonController.fnum; i++)
        {
            roles.Add(2);
        }
    }

    void csvread()
    {
        csvFile = Resources.Load("word") as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
            height++;
        }
    }
}
