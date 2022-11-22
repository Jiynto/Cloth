using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerBehaviour : CharacterBase
{
    private new PlayerAnimation animation;
    
    [SerializeField]
    Animator animator;
    
    private void Start()
    {
        // set the players starting state to grounded.
        state = CharacterState.Idle;

    }

    public void ChangeState(bool move, bool jump, bool dash, bool attack)
    {
        state = newState;
    }
    
    private void Update()
    {
        
        // animate the player
        animation.Animate(animator, state);
    }
    
    

    private void FixedUpdate()
    {
        // if movement input flagged then move.
        if (move)
        {
            movement.Move(direction);
            if (state != CharacterState.Airborne)
            {
                state = CharacterState.Moving;
            }
        }

        // if jump input flagged then jump.
        if (jump)
        {
            movement.Jump();
            state = CharacterState.Airborne;
            jump = false;
        }
    }

    
}
