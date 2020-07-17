using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerGate : MonoBehaviour, Killable, Damageable
{
    public float GateHealth = 2000f;

    private void Update()
    {
        if (GateHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }

    public void TakeDamage(float Damage)
    {
        GateHealth -= Damage;
    }
}
