using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float dashModifier;

    private float moveModifier;

    [SerializeField]
    private Rigidbody2D rb;

    private float direction = 1;

    private bool locked = false;

    private bool dash = false;

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

    private void Start()
    {
        moveModifier = 0;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if(!locked)
        {
            rb.velocity = Move();
            if (jump)
            {
                rb.AddForce(rb.transform.up * 100);
                jump = false;
            }
        }

    }

    private Vector2 Move()
    {
        if(dash)
        {
            locked = true;
            return new Vector2(direction * dashModifier, rb.velocity.y);
        }
        return new Vector2(direction * moveModifier, rb.velocity.y);
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
        moveModifier = moveSpeed;
    }

    private void HorizontalEnd(InputAction.CallbackContext context)
    {
        moveModifier = 0;
    }

    private void Dash()
    {
        Debug.Log("Dash");
        dash = true;
    }

    private void FinishDash()
    {
        dash = false;
        locked = false;
    }

    //private void Slide()
    //{
    //    Debug.Log("Slide");
    //}
    private void Animate()
    {

    }

    private void Attack()
    {

    }


}
