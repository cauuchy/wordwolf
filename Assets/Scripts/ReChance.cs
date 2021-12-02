using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReChance : MonoBehaviour
{
    [SerializeField] private InputField vipf, wipf;
    [SerializeField] private GameObject popout;

    void Start()
    {
        popout.SetActive(false);
    }

    public void onSubmit()
    {
        if(vipf.text == Confirm.villager
            && wipf.text == Confirm.wolf
            && vipf.text != ""
            && wipf.text != "")
        {
            SettingsButtonController.who = 2;
            SceneManager.LoadScene("Result0");
        }
        else
        {
            popout.SetActive(true);
        }
    }

    public void onSubmit2()
    {
        if (vipf.text == Confirm.villager
            && vipf.text != "")
        {
            SettingsButtonController.who = 1;
            SceneManager.LoadScene("Result0");
        }
        else
        {
            SettingsButtonController.who = 0;
            SceneManager.LoadScene("Result0");
        }
    }

    public void popoutClick()
    {
        SceneManager.LoadScene("VoteWolf");
    }

    public void FoxWin() {
        SettingsButtonController.who = 2;
        SceneManager.LoadScene("Result0");
    }

    public void FoxLose() {
        SceneManager.LoadScene("VoteWolf");
    }

    public void WolfWin() {
        SettingsButtonController.who = 1;
        SceneManager.LoadScene("Result0");
    }

    public void WolfLose() {
        SettingsButtonController.who = 0;
        SceneManager.LoadScene("Result0");
    }
}
