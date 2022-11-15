using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    // state of the characters movement.
    protected CharacterState state;
    // the direction the character is facing, used for sprite flipping and movement calculations.
    protected float direction = 1;


    // flips the player sprite based on a given direction.
    protected void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
