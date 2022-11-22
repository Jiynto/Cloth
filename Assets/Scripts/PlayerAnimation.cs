using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAnimation : IAnimated
{


    /// <summary>
    /// animate the player
    /// </summary>
    /// <param name="animator"></param>
    public void Animate(Animator animator, CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Dashing:
                animator.SetBool("Dash", true);
                animator.SetBool("Run", false);
                break;
            // if airborne, play the jump animation and not the run animation.
            case CharacterState.Airborne:
                animator.SetBool("Run", false);
                animator.SetBool("Jump", true);
                break;
            // if moving, play the run animation
            case CharacterState.Moving:
                animator.SetBool("Run", true);
                animator.SetBool("Jump", false);
                break;
            // default to idle.
            default:
                animator.SetBool("Run", false);
                animator.SetBool("Jump", false);
                break;

        }
    }
}
