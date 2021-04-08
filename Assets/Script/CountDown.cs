using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public static CountDown countDown;
    public int countDownTime;
    public Text countDisplay;

    public void Start()
    {
        StartCoroutine(countDownToStart());
    }
    public IEnumerator countDownToStart()
    {
        while (countDownTime > 0)
        {
            countDisplay.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        countDisplay.text = "SURVIVE";

        Timer.timer.beginTimer();
        //GameManager.gameManager.beginGame();

        yield return new WaitForSeconds(1f);

        countDisplay.gameObject.SetActive(false);
    }
}
