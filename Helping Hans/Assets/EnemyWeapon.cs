using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public EnemyWeaponType weaponType;
    public float Damage;
    public string TargetTag;
    public float Speed;

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * Speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (weaponType == EnemyWeaponType.Rifle)
        {
            Speed = 40f;
            TargetTag = "Bunker";
            Damage = 5f;
        }

        if (weaponType == EnemyWeaponType.Bazoka)
        {
            Speed = 20f;
            TargetTag = "Bunker";
            Damage = 50f;
        }

        if (weaponType == EnemyWeaponType.Charger)
        {
            Speed = 10f;
            TargetTag = "Gate";
            Damage = 200f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(TargetTag))
        {
            if (collision.transform.CompareTag("Bunker"))
            {
                collision.GetComponent<Bunker>().Health -= Damage;
                Destroy(gameObject);
            }
            else if (collision.transform.CompareTag("Gate"))
            {
                collision.GetComponent<BunkerGate>().GateHealth -= Damage;
                Destroy(gameObject);
            }
        }
    }
}
