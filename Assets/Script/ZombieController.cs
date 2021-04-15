using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public static ZombieController zombieController;

    Rigidbody rb;
    private GameObject target;
    public float moveSpeed;
    public float zombieStrength;
    Vector3 dirToTarget;
    public static bool spawnAllowed;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        Debug.Log("FoundPlayer");
        rb = GetComponent<Rigidbody>();
        moveSpeed = UnityEngine.Random.Range(5f, 8.5f);
        
    }

    void Update()
    {
        MoveZombie();
    }

    public void GetZombieStrength()
    {
        zombieStrength = UnityEngine.Random.Range(15f, 25f);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                ZombieController.spawnAllowed = false;
                //Destroy(other.gameObject);
                target = null;
                break;
        }
    }

    private void MoveZombie()
    {
        if (target != null)
        {
            dirToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector3(dirToTarget.x * moveSpeed,0, dirToTarget.z * moveSpeed);

            //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //rb.MovePosition(pos);
            //transform.LookAt(target);
            transform.LookAt(target.transform);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
