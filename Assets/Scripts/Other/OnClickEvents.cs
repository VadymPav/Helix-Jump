using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;

    private void Start()
    {
        if (GameManager.mute)
            soundsText.text = "/";
        else
            soundsText.text = "";

    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundsText.text = "/";
        }
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
