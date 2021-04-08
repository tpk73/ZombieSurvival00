using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public Text countDown;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        //CountDown.countDown.StartCoroutine(countDownToStart());
    }
    public void beginGame()
    {
        Time.timeScale = 1f;
    }


}
