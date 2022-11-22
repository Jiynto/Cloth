using UnityEngine;


public sealed class PlayerAnimation : IAnimated
{

    private static readonly int Move = Animator.StringToHash("Run");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Dash = Animator.StringToHash("Dash");


    /// <summary>
/// sets animation parameters based on the current player state
/// </summary>
/// <param name="animator"></param>
/// <param name="state"></param>
    public void Animate(Animator animator, CharacterState state)
    {
        switch (state)
        {
            // if dashing, play dashing animation and not the other two.
            case CharacterState.Dashing:
                animator.SetBool(Dash, true);
                animator.SetBool(Move, false);
                animator.SetBool(Jump, false);
                break;
            // if airborne, play the jump animation and not the run animation.
            case CharacterState.Airborne:
                animator.SetBool(Move, false);
                animator.SetBool(Jump, true);
                animator.SetBool(Dash, false);
                break;
            // if moving, play the run animation
            case CharacterState.Moving:
                animator.SetBool(Move, true);
                animator.SetBool(Jump, false);
                animator.SetBool(Dash, false);
                break;
            // default to idle.
            default:
                animator.SetBool(Move, false);
                animator.SetBool(Jump, false);
                animator.SetBool(Dash, false);
                break;

        }
    }
}
