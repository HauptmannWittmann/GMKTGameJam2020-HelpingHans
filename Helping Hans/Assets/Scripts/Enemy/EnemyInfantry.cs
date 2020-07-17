using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfantry : MonoBehaviour, Damageable, Killable
{
    [Header("Enemy Properties")]
    public float Speed;
    public float Health;
    public float Range;
    public float ReloadTime;

    [SerializeField] float CurrentReloadTime;
    [SerializeField] string TargetTag;
    [SerializeField] bool isStop = false;

    [Header("Enemy Components")]
    public GameObject Target;
    public GameObject enemyWeapon;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Observing", 0f, 0.5f);
        CurrentReloadTime = ReloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if (Health <= 0)
            Die();

        if (isStop)
        {
            if (Target == null)
            {
                return;
            }
            else
            {
                Aimming();
                Firing();
            }
        }
    }

    private void Firing()
    {
        if (CurrentReloadTime > 0)
            CurrentReloadTime -= Time.deltaTime;
        else
        {
            Instantiate(enemyWeapon, transform.position, transform.rotation);
            CurrentReloadTime = ReloadTime;
        }
    }

    private void Aimming()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Target.transform.position - transform.position);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    }

    public void Die()
    {
        Destroy(gameObject);
        UIManager.ScoreCount++;
    }


    public void Observing()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(TargetTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            Target = nearestEnemy.gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Health -= collision.GetComponent<Bullet>().Damage;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Beach Line"))
        {
            Speed = 0;
            isStop = true;
        }
    }
}
