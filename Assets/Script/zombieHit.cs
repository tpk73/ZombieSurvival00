using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zombieHit : MonoBehaviour
{
    public static zombieHit hit;
    public GameObject deathscrn;
    public int zombieStrength = 18;
    private int sec = 3;
   
    private void Start()
    {
        deathscrn.gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player play = other.GetComponent<Player>();
            play.ReduceHealth(zombieStrength);
        }
    }

}
