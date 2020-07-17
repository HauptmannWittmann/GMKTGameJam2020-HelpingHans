using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmor : MonoBehaviour
{
    [Header("Enemy Properties")]
    public float Speed;
    public float Health;
    public float Range;
    public float ReloadTime;

    [SerializeField] float CurrentReloadTime;
    [SerializeField] string TargetTag;
    float OriSpeed;

    [Header("Enemy Components")]
    public GameObject Turret;
    public GameObject FirePoint;
    public GameObject Target;
    public GameObject enemyWeapon;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Observing", 0f, 0.5f);
        Speed = Random.Range(Speed /2, Speed);
        Range = Random.Range(Range - 10f, Range);
        CurrentReloadTime = ReloadTime;
        OriSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if (Health <= 0)
            Die();

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

    private void Firing()
    {
        if (CurrentReloadTime > 0)
            CurrentReloadTime -= Time.deltaTime;
        else
        {
            GameObject newEnemy = Instantiate(enemyWeapon, FirePoint.transform.position, FirePoint.transform.rotation);
            newEnemy.transform.SetParent(this.transform);
            CurrentReloadTime = ReloadTime;
        }
    }

    private void Aimming()
    {
        Turret.transform.rotation = Quaternion.LookRotation(Vector3.forward, Target.transform.position - Turret.transform.position);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    }

    public void Die()
    {
        Destroy(gameObject);
        UIManager.ScoreCount += 5;
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
            Speed = 0;
        }
        else 
        {
            Speed = OriSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("AT Shell"))
        {
            Health -= collision.GetComponent<ATShell>().Damage;
            Destroy(collision.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
