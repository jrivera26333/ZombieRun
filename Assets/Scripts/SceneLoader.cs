﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
