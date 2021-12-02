using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    [SerializeField]
    private RectTransform prefab = null;

    static public string[] playerName =
    {
        "プレイヤー1",
        "プレイヤー2",
        "プレイヤー3",
        "プレイヤー4",
        "プレイヤー5",
        "プレイヤー6",
        "プレイヤー7",
        "プレイヤー8",
        "プレイヤー9",
        "プレイヤー10",
        "プレイヤー11",
        "プレイヤー12",
        "プレイヤー13",
        "プレイヤー14",
        "プレイヤー15",
        "プレイヤー16",
        "プレイヤー17",
        "プレイヤー18",
        "プレイヤー19",
        "プレイヤー20"
    };
    

    void Start()
    {
        for (int i = 0; i < SettingsButtonController.total; i++)
        {
            // create prefabs
            var item = GameObject.Instantiate(prefab) as RectTransform;
            item.SetParent(transform, false);

            // set a player number
            var text = item.GetComponentsInChildren<Text>();
            text[0].text = (i+1).ToString() + ":";

            // set a player name
            var p = item.GetComponentInChildren<InputField>();
            p.text = playerName[i];
        }
    }
}