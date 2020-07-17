using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bunker : MonoBehaviour, Damageable
{
    public float Health = 1000f;
    public AmmunitionType AmmunitionType;
    public int AmmoBox = 0;
    public Image icon;

    private void Update()
    {
        if (Health < 0)
        {
            Destroy(gameObject);
        }

        if (AmmoBox > 0)
        {
            icon.enabled = true;
        }
        else
            icon.enabled = false;
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    }
}
