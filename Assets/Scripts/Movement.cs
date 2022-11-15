using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IMoveable
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed;


    [SerializeField]
    private float jumpForce;

    /// <summary>
    /// Makes the player move based on the current direction being faces and the movespeed value.
    /// </summary>
    public void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
    }

    /// <summary>
    /// Makes the player jump using addforce
    /// also sets the player state to in air and the jump flag to false, so it only applies once.
    /// </summary>
    public void Jump()
    {
        rb.AddForce(rb.transform.up * jumpForce);
    }


    public void Stop()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
