﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTitle : MonoBehaviour
{
    public void moveTitle()
    {
        SceneManager.LoadScene("Main");
    }

    public void moveHowto()
    {
        SceneManager.LoadScene("Howto");
    }
}
