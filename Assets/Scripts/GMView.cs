using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMView : MonoBehaviour
{
    [SerializeField]
    private Text label;
    private string t;
    private List<int> v = new List<int>();
    private List<int> w = new List<int>();
    private List<int> f = new List<int>();

    void Start()
    {
        for (int i = 0; i < SettingsButtonController.total; i++)
        {
            if (Confirm.roles[i] == 0)
            {
                v.Add(i);
            }
            else if(Confirm.roles[i] == 1)
            {
                w.Add(i);
            }
            else
            {
                f.Add(i);
            }
        }

        t = "\n<color=#008000ff>市民「" + Confirm.villager + "」\n";

        for (int i = 0; i < SettingsButtonController.vnum; i++)
        {
            t += ScrollController.playerName[v[i]] + "\n";
        }

        t += "</color>\n";

        t += "<color=#ff0000ff>人狼「" + Confirm.wolf + "」\n";

        for (int i = 0; i < SettingsButtonController.wnum; i++)
        {
            t += ScrollController.playerName[w[i]] + "\n";
        }

        t += "</color>\n";

        t += "<color=#c71585ff>妖狐「" + Confirm.fox + "」\n";

        for (int i = 0; i < SettingsButtonController.fnum; i++)
        {
            t += ScrollController.playerName[f[i]] + "\n";
        }

        t += "</color>";

        label.text = t;
    }
}
