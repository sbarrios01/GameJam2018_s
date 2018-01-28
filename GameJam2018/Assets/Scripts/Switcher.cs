﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switcher : MonoBehaviour {
    public void GoToGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
