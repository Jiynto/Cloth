using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimated
{
    void Animate(Animator animator, CharacterState state);
}
