using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 


    
    private IMovable2D movement;

    [SerializeField]
    private PlayerInput playerInput;

    private InputAction jumpAction;

    private InputAction moveAction;
    
    private Action<InputAction.CallbackContext> jumpHandler;



    private void Awake()
    {
        // Setting the movement actions.
        jumpAction = playerInput.actions["Jump"];
        moveAction = playerInput.actions["Move"];

        // creating a handler for the jump action.
        jumpHandler = delegate { JumpTrigger(); };

        // assign action events to appropriate methods.
        jumpAction.performed += jumpHandler;
        moveAction.started += HorizontalInput;
        moveAction.canceled += HorizontalEnd;



    }

    private void Start()
    {
        movement = gameObject.GetComponent<IMovable2D>();
        //animation = new PlayerAnimation();

    }


  

    /// <summary>
    /// sets a flag to jump if there is a jump input, but only if the player state is not in the air.
    /// </summary>
    private void JumpTrigger()
    {
        Debug.Log("Jump");
        if (state != CharacterState.Airborne)
        {
            jump = true;
        }

    }


    /// <summary>
    /// flags the player to move, and flips the player sprite based on the input axis value.
    /// </summary>
    /// <param name="context"></param>
    private void HorizontalInput(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<float>());

        if (direction != context.ReadValue<float>())
        {
            direction = -direction;
            Flip();
        }

        move = true;
    }


    /// <summary>
    /// switches the movement flag off so the player stops moving, and resets their velocity to prevent drift.
    /// </summary>
    /// <param name="context"></param>
    private void HorizontalEnd(InputAction.CallbackContext context)
    {
        if (state == CharacterState.Moving) state = CharacterState.Idle;
        movement.Stop();
        move = false;
    }


    private void Dash()
    {
        Debug.Log("Dash");
        dash = true;
    }

    private void FinishDash()
    {
        animator.SetBool("Dash", false);
        dash = false;
    }

    //private void Slide()
    //{
    //    Debug.Log("Slide");
    //}

   



    /// <summary>
    /// unsubscribe the action listeners. Used before the player is disabled or destroyed.
    /// </summary>
    public void Unsubscribe()
    {
        jumpAction.performed -= jumpHandler;
        moveAction.started -= HorizontalInput;
        moveAction.canceled -= HorizontalEnd;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the player hits the gound, set playerState to grounded.
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            state = CharacterState.Idle;
            //return;
        }
        /*
        if (collision.collider.gameObject.tag == "EnemyHead")
        {

            collision.gameObject.GetComponent<EnemyController>().TakeDamage(Damage);
            //Debug.Log("enemy took damage: " + collision.gameObject.GetComponentInParent<EnemyController>().Health);

        }
        */
    }
   


    private void Attack()
    {

    }


}
