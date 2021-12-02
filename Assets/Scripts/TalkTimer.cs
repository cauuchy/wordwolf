using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TalkTimer : MonoBehaviour
{
    //　トータル制限時間
    private float totalTime;
    //　制限時間（分）
    [SerializeField]
    private int minute;
    //　制限時間（秒）
    [SerializeField]
    private float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    private Text timerText;
    // GMモード用
    [SerializeField] private GameObject gmButton, gmView;

    void Start()
    {
        minute = SettingsButtonController.timer;
        seconds = 0f;
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
        gmView.SetActive(false);
        if(!SettingsButtonController.gmMode) gmButton.SetActive(false);
    }

    void Update()
    {
        if (totalTime > 0f)
        {
            totalTime = minute * 60 + seconds;
            totalTime -= Time.deltaTime;

            minute = (int)totalTime / 60;
            seconds = totalTime - minute * 60;

            if (seconds < 0) seconds = 0f;

            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
            oldSeconds = seconds;
        }
        else
        {
            if (minute >= 1)
                totalTime = minute * 60 + seconds;
            else
            {
                minute = 0;
                seconds = 0f;
            }
        }
    }

    public void OnClick(int buttonNum)
    {
        if (buttonNum == 0)
            minute += 1;
        else
            minute -= 1;
    }

    public void timeover()
    {
        SceneManager.LoadScene("VoteFox");
    }
}
