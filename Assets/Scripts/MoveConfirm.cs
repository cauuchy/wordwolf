using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveConfirm : MonoBehaviour
{
    public void OnClick()
    {
        if(SettingsButtonController.gmMode)
        {
            SceneManager.LoadSceneAsync("GameMaster");
        }
        else
        {
            SceneManager.LoadSceneAsync("Confirm");
        }
    }
}
