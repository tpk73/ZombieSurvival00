using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static HealthController playerController;

    public float health;

   public HealthController(float health)
    {
        this.health = health;
    }
    
    public float GetHealth()
    {
        return health;
    }

    public void Damage(float damageAmount)
    {
        health -= ZombieController.zombieController.zombieStrength;
    }
    public void Heal(float healAmount)
    {
        health += healAmount;
    }
}
