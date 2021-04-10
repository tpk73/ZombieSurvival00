using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public float moveSpeed = 2;
    public float rotSpeed = 2;

    private Rigidbody rb;

    private Vector3 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horMove = moveJoystick.Horizontal;
        float verMove = moveJoystick.Vertical;

        dir = new Vector3(horMove, 0f, verMove);

        if(dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.deltaTime);
        }

        transform.Translate(transform.position + moveSpeed * Time.deltaTime * dir);
    }
}
