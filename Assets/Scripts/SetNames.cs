using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetNames : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Names");
    }
}
