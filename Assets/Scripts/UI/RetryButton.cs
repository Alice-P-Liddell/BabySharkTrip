﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public Text scoreText;

    public void ClickRetryButton()
    {
        SceneManager.LoadScene("Game");
    }
}
