using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Candidates2 : MonoBehaviour
{
    [SerializeField] private RectTransform prefab = null;
    [SerializeField] private ToggleGroup toggleGroup;
    private Toggle toggle;
    private List<int> vw = new List<int>();

    void Start()
    {
        for (int i = 0; i < SettingsButtonController.total; i++)
        {
            if (Confirm.roles[i] != 2)
            {
                vw.Add(i);
            }
        }

        var N = SettingsButtonController.vnum + SettingsButtonController.wnum;

        for (int i = 0; i < N; i++)
        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);
            item.GetComponentInChildren<ToggleNumber>().number = vw[i];
            item.GetComponentInChildren<Toggle>().group = toggleGroup;
            item.GetComponentInChildren<Toggle>().onValueChanged.AddListener(OnSelectItem);

            var text = item.GetComponentInChildren<Text>();
            text.text = ScrollController.playerName[vw[i]];
        }
    }

    void OnSelectItem(bool flg)
    {
        Toggle activeItem = toggleGroup.ActiveToggles().FirstOrDefault();
    }

    public void OnClick()
    {
        if (toggleGroup.AnyTogglesOn())
        {
            toggle = toggleGroup.ActiveToggles().FirstOrDefault();
            var num = toggle.GetComponent<ToggleNumber>().number;
            if (Confirm.roles[num] != 1)       // wolf won
            {
                SettingsButtonController.who = 1;
                SceneManager.LoadScene("Result0");
            }
            else
            {
                if (SettingsButtonController.re_w)
                {
                    if(SettingsButtonController.gmMode)
                    {
                        SceneManager.LoadScene("WolfChanceGM");
                    }
                    else
                    {
                        SceneManager.LoadScene("WolfChance");
                    }
                }
                else
                {
                    SettingsButtonController.who = 0;
                    SceneManager.LoadScene("Result0");
                }
            }
        }
    }
}
