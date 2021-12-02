using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonController : MonoBehaviour
{
    [SerializeField] private Text vlabel, wlabel, flabel, tlabel, timerLabel;
    [SerializeField] private Toggle wtoggle, ftoggle, gmtoggle;
    public static bool re_w = false, re_f = true, gmMode = false;
    public static int who = -1;
    public static int vnum = 3;        // number of villagers
    public static int wnum = 1;        // number of wolves
    public static int fnum = 1;        // number of foxes
    public static int total = 5;       // number of whole roles
    public static int timer = 10;      // talk time

    void Start()
    {
        ftoggle.isOn = re_f;
        wtoggle.isOn = re_w;
        gmtoggle.isOn = gmMode;
        UpdateLabel(vnum, vlabel);
        UpdateLabel(wnum, wlabel);
        UpdateLabel(fnum, flabel);
        UpdateLabel(timer, timerLabel);
    }

    void Update()
    {
        total = vnum + wnum + fnum;
        UpdateLabel(total, tlabel);
    }

    public void Click(string buttonName)
    {
        switch (buttonName)
        {
            case "vplus":           // clicked villager plus button
                vnum++;
                if (vnum > 9) vnum = 9;
                UpdateLabel(vnum, vlabel);
                break;

            case "vminus":          // clicked villager minus button
                vnum--;

                if (vnum < 3) vnum = 3;
                UpdateLabel(vnum, vlabel);

                // always keep vnum >= wnum + 1
                if (wnum >= vnum) wnum = vnum - 1;
                UpdateLabel(wnum, wlabel);

                if (fnum >= (vnum - 1)) fnum = vnum - 2;    // always keep vnum >= fnum + 2
                if (fnum >= wnum) fnum = wnum - 1;          // always keep wnum >= fnum + 1
                if (vnum <= 3 || fnum <= 0) fnum = 1;
                if (fnum > 4) fnum = 4;
                UpdateLabel(fnum, flabel);
                break;

            case "wplus":           // clicked wolf plus button
                wnum++;

                // always keep vnum >= wnum + 1
                if (wnum >= vnum) wnum = vnum - 1;

                if (vnum <= 2) wnum = 1;
                if (wnum > 9) wnum = 9;
                UpdateLabel(wnum, wlabel);
                break;

            case "wminus":          // clicked wolf minus button
                wnum--;

                if (vnum <= 3) wnum = 1;
                if (wnum <= 0) wnum = 1;
                UpdateLabel(wnum, wlabel);

                if (fnum >= wnum) fnum = wnum - 1;      // always keep wnum >= fnum + 1
                if (fnum <= 0) fnum = 1;
                UpdateLabel(fnum, flabel);

                break;

            case "fplus":           // clicked fox plus button
                fnum++;

                if (fnum >= (vnum - 1)) fnum = vnum - 2;    // always keep vnum >= fnum + 2
                if (fnum >= wnum) fnum = wnum - 1;          // always keep wnum >= fnum + 1
                if (vnum <= 3 || fnum <= 0) fnum = 1;
                if (fnum > 3) fnum = 3;
                UpdateLabel(fnum, flabel);
                break;

            case "fminus":          // clicked fox minus button
                fnum--;

                if (vnum <= 3) fnum = 1;
                if (fnum <= 0) fnum = 1;
                UpdateLabel(fnum, flabel);
                break;

            case "timeplus":        // clicked time plus button
                timer++;

                if (timer > 60) timer = 60;
                UpdateLabel(timer, timerLabel);
                break;

            case "timeminus":       // clicked time minus button
                timer--;

                if (timer < 1) timer = 1;
                UpdateLabel(timer, timerLabel);
                break;
        }
    }

    public void ValueChanged(int n)
    {
        if (n == 0)
        {
            re_f = ftoggle.isOn;
        }
        else if (n == 1)
        {
            re_w = wtoggle.isOn;
        }
        else if (n == 2)
        {
            gmMode = gmtoggle.isOn;
        }
    }

    void UpdateLabel(int num, Text label)
    {
        label.text = num.ToString();
    }
}
