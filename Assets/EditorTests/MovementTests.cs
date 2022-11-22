using NUnit.Framework;
using UnityEngine;


public class MovementTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void MoveTest()
    {
        var gameObject = new GameObject();

        gameObject.AddComponent<Movement>();
        gameObject.AddComponent<Rigidbody2D>();
        Movement movement = gameObject.GetComponent<Movement>();
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        movement.rb = rb;
        movement.moveSpeed = 1;
        
        movement.Move(0);
        Assert.AreEqual(0, rb.velocity.x);
        
        movement.Move(-1);
        Assert.AreEqual(-1, rb.velocity.x);
        
        movement.Move(0);
        Assert.AreEqual(-1, rb.velocity.x);
        
        movement.Move(1);
        Assert.AreEqual(1, rb.velocity.x);

        movement.Move(-2);
        Assert.AreEqual(-1, rb.velocity.x);
        movement.Move(2);
        Assert.AreEqual(1, rb.velocity.x);
    }

    [Test]
    public void StopTest()
    {
        var gameObject = new GameObject();

        gameObject.AddComponent<Movement>();
        gameObject.AddComponent<Rigidbody2D>();
        Movement movement = gameObject.GetComponent<Movement>();
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        movement.rb = rb;
        rb.velocity = new Vector2(1, 0);
        movement.Stop();
        Assert.AreEqual(0, rb.velocity.x);
    }

}
