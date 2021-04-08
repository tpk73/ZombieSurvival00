using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player player;
    public Rigidbody myRB;

    [Header("Speed")]
    public float movementspeed = 1f;
    
    [Header("Health")]
    public int maxHealth = 100;
    public int currHealth;
    public Canvas healthBar;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        currHealth = maxHealth;
    }

    void Update()
    {
        float moveSpeed = movementspeed;

        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        
        float horizontalInput2 = Input.GetAxis("Mouse X");

        ReduceHealth(zombieHit.hit.zombieStrength);
    }

    public void ReduceHealth(int damage)
    {
        currHealth -= damage;
        HealthBar.playerHealth.SetHealth(currHealth);
    }
}
   


