using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController gameController;
    public Text countDown;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        HealthController healthController = new HealthController(100f);
        Debug.Log("Health: " + healthController.GetHealth());

        healthController.Damage(ZombieController.zombieController.GetZombieStrength(ZombieController.zombieController.zombieStrength));


        Time.timeScale = 0f;
        //CountDown.countDown.StartCoroutine(countDownToStart());
    }
    public void beginGame()
    {
        Time.timeScale = 1f;
    }


}
