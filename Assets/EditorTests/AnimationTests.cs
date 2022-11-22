using NUnit.Framework;
using UnityEngine;

public class AnimationTests
{
    private GameObject player;
    private Animator animator;
    private PlayerAnimation animation;
    
    [SetUp]
    public void SetUp()
    {
        player= Resources.Load("Prefabs/Player") as GameObject;
        player = Object.Instantiate(player);
        animator = player.GetComponent<Animator>();
        animation = new PlayerAnimation();
    }
    
    
    [Test]
    public void AnimationTestIdle()
    {
        animation.Animate(animator, CharacterState.Idle);
        Assert.AreEqual(false, animator.GetBool("Run"));
        Assert.AreEqual(false, animator.GetBool("Jump"));
        Assert.AreEqual(false, animator.GetBool("Dash"));
    }
    
    [Test]
    public void AnimationTestMove()
    {
        animation.Animate(animator, CharacterState.Moving);
        Assert.AreEqual(true, animator.GetBool("Run"));
        Assert.AreEqual(false, animator.GetBool("Jump"));
        Assert.AreEqual(false, animator.GetBool("Dash"));
    }
    
    [Test]
    public void AnimationTestJump()
    {
        animation.Animate(animator, CharacterState.Airborne);
        Assert.AreEqual(false, animator.GetBool("Run"));
        Assert.AreEqual(true, animator.GetBool("Jump"));
        Assert.AreEqual(false, animator.GetBool("Dash"));
    }
    
    [Test]
    public void AnimationTestDash()
    {
        animation.Animate(animator, CharacterState.Dashing);
        Assert.AreEqual(false, animator.GetBool("Run"));
        Assert.AreEqual(false, animator.GetBool("Jump"));
        Assert.AreEqual(true, animator.GetBool("Dash"));
    }
    
    

}
