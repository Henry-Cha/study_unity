﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesCtrl : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void ChangeToScene()

        {
        SceneManager.LoadScene("game");
        }

    public void ExidScene()
    {
        Application.Quit();
    }

}
