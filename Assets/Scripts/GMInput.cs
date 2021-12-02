using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMInput : MonoBehaviour
{
    [SerializeField] private GameObject popout;
    [SerializeField] private InputField vipf, wipf, fipf;
    public static string vtxt, wtxt, ftxt;
    private string txt = "";
    public Text label;

    void Start()
    {
        popout.SetActive(false);
    }

    public void OnClick()
    {
        if(vipf.text == "" || wipf.text == "" || fipf.text == "")
        {
            txt = "未入力の項目があります。\nお題がランダムで\n設定されますが、\nよろしいですか？\n";
        }
        else
        {
            txt = "市民「" + vipf.text + "」\n人狼「" + wipf.text + "」\n妖狐「" + fipf.text + "」\nで始めます。\nよろしいですか？\n\n";
        }

        label.text = txt;

        popout.SetActive(true);
    }

    public void Check()
    {
        vtxt = vipf.text;
        wtxt = wipf.text;
        ftxt = fipf.text;

        SceneManager.LoadSceneAsync("Confirm");
    }

    public void Cancel()
    {
        popout.SetActive(false);
    }
}
