using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterBase, IHealth, IAnimated
{
    [field: SerializeField]
    public int Health { get; set; }


    [SerializeField]
    private IMoveable movement;


    [SerializeField]
    private Animator animator;


    [field: SerializeField]
    private int Damage { get; set; }


    void Awake()
    {
        // set starting state to idle.
        state = CharacterState.Idle;
    }

    private void Start()
    {
        movement = gameObject.GetComponent<Movement>();
    }

    void Update()
    {
        // animates the enemy
        Animate(animator);
    }


    void FixedUpdate()
    {
        movement.Move(direction);

    }

    /// <summary>
    /// Kills the player and resets the game.
    /// </summary>
    public void Die()
    {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }


    /// <summary>
    /// damages the player by the given amount
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0) Die();
    }



    /// <summary>
    /// Animates the character
    /// </summary>
    /// <param name="animator"></param>
    public void Animate(Animator animator)
    {

        switch (state)
        {
            // if airborne, dont bother playing a walk animation.
            // would only really matter if in the future there are ways to knock enemies off ledges.
            case CharacterState.Airborne:
                animator.SetBool("Run", false);
                break;
            // if moving play the walk animation
            case CharacterState.Moving:
                animator.SetBool("Run", true);
                break;
            default:
                animator.SetBool("Run", false);
                break;

        }

    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // makes sure that it was the body that collided and not the head, as the head should not deal damage but only take damage.
        if (collision.GetContact(0).otherCollider.gameObject.tag == "EnemyHead") return;

        // if colliding with the player, deal damage to them.
        if (collision.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(Damage);
            Debug.Log("player took damage: " + collision.gameObject.GetComponent<PlayerController>().Health);
            // disables the head, as physics of collisions is instant so the player could hit the head before being pushed back.
            head.enabled = false;

        }
    }
    */
}
