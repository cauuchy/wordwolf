using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Candidates : MonoBehaviour
{
    [SerializeField]
    private RectTransform prefab = null;
    private Toggle toggle;
    public ToggleGroup toggleGroup;

    void Start()
    {
        for (int i = 0; i < SettingsButtonController.total; i++)
        {
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);
            item.GetComponentInChildren<ToggleNumber>().number = i;
            item.GetComponentInChildren<Toggle>().group = toggleGroup;
            item.GetComponentInChildren<Toggle>().onValueChanged.AddListener(OnSelectItem);

            var text = item.GetComponentInChildren<Text>();
            text.text = ScrollController.playerName[i];
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
            if(Confirm.roles[num] != 2)
            {
                SettingsButtonController.who = 2;
                SceneManager.LoadScene("Result0");
            }
            else        // killed fox
            {
                if (SettingsButtonController.re_f)
                {
                    if(SettingsButtonController.gmMode)
                    {
                        SceneManager.LoadScene("FoxChanceGM");
                    }
                    else
                    {
                        SceneManager.LoadScene("FoxChance");
                    }
                }
                else
                {
                    SceneManager.LoadScene("VoteWolf");
                }
            }
        }
    }
}
