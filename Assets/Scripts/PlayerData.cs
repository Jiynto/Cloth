using UnityEngine;
using UnityEngine.Events;

public class PlayerData : MonoBehaviour, IHealth
{
    public UnityEvent deathFlag;
    
    [field: SerializeField]
    public int Health { get; set; }

    [field: SerializeField]
    private int Damage { get; set; }
    
    
    
    /// <summary>
    /// Kills the player and resets the game.
    /// </summary>
    public void Die()
    {
        deathFlag.Invoke();
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

    
}
