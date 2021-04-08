using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerControl : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    private ManagerJoystick mgrJoyStick;

    private float inputX;
    private float inputZ;
    private Vector3 Vmovement;
    private Vector3 Vvelocity;
    private float moveSpeed;
    private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        characterController = tempPlayer.GetComponent<CharacterController>();
        animator = tempPlayer.transform.GetChild(0).GetComponent<Animator>();

        moveSpeed = 10f;
        gravity = 0.5f;

        mgrJoyStick = GameObject.Find("joystickBG").GetComponent<ManagerJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        //inputX = Input.GetAxis("Horizontal");
        //inputZ = Input.GetAxis("Vertical");
        inputX = mgrJoyStick.inputHorizontal();
        inputZ = mgrJoyStick.inputVertical();

        if(inputZ == 0)
        {
            animator.SetBool("IsMoving", false);
        }
        else
        {
            animator.SetBool("IsMoving", true);
        }
    }

    private void FixedUpdate()
    {
        if (characterController.isGrounded)
        {
            Vvelocity.y = 0f;
        }
        else
        {
            Vvelocity.y -= gravity * Time.deltaTime;
        }

        Vmovement = characterController.transform.forward * inputZ;
        characterController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));
        characterController.Move(Vmovement * moveSpeed * Time.deltaTime);
        characterController.Move(Vvelocity);
    }
}
