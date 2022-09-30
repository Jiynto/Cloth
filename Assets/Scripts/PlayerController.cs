using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    private float direction = 1;

    private bool move = false;

    private bool jump = false;

    private float horizontalVelocity = 0;

    #region Input Actions
    [SerializeField]
    private PlayerInput playerInput;

    private InputAction jumpAction;

    private InputAction moveAction;

    private InputAction slideAction;

    private InputAction dashAction;

    private InputAction attackAction;
    #endregion

    private void Awake()
    {
        jumpAction = playerInput.actions["Jump"];
        moveAction = playerInput.actions["Move"];
        //slideAction = playerInput.actions["Slide"];
        dashAction = playerInput.actions["Dash"];
        attackAction = playerInput.actions["Attack"];

        Action<InputAction.CallbackContext> jumpHandler = delegate (InputAction.CallbackContext context) {Jump(); };
        Action<InputAction.CallbackContext> dashHandler = delegate (InputAction.CallbackContext context) {Dash(); };
        //Action<InputAction.CallbackContext> slideHandler = delegate (InputAction.CallbackContext context) {Slide(); };

        jumpAction.performed += jumpHandler;
        //slideAction.performed += slideHandler;
        dashAction.performed += dashHandler;
        moveAction.started += HorizontalInput;
        moveAction.canceled += HorizontalEnd;

    }

    private void Update()
    {
        SetMoveValues();
    }

    private void FixedUpdate()
    {
        Move();
        if(jump)
        {
            rb.AddForce(rb.transform.up * 100);
            jump = false;
        }
    }

    private void Jump()
    {
        Debug.Log("Jump");
        jump = true;
    }


    private void HorizontalInput(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>());
        direction = context.ReadValue<float>();
        move = true;
    }

    private void HorizontalEnd(InputAction.CallbackContext context)
    {
        move = false;
    }

    private void SetMoveValues()
    {

        if(move)
        {
            horizontalVelocity = direction * moveSpeed;
        }
        else
        {
            horizontalVelocity = 0;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
    }

    private void Dash()
    {
        Debug.Log("Dash");
    }

    //private void Slide()
    //{
    //    Debug.Log("Slide");
    //}
    private void Attack()
    {

    }
}
