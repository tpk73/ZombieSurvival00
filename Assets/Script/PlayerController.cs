using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;

    public float health;

    private void Start()
    {
        health = 100f;
    }

    public void UpdateHealth(int damage)
    {
        //health = health - ZombieController.zombieController.zombieStrength;
    }
}
