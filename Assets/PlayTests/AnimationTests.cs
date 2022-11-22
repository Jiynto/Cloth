using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AnimationTests
{
    [Test]
    public void AnimationTest()
    {
        GameObject player= Resources.Load("Prefabs/Player") as GameObject;
        player = Object.Instantiate(player);

        Animator animator = player.GetComponent<Animator>();
        //PlayerController player_controller = player.GetComponent<PlayerController>();


        PlayerAnimation animation = new PlayerAnimation();
        
        animation.Animate(animator, CharacterState.Idle);
        Assert.AreEqual(true, animator.GetParameter());




    }

}
