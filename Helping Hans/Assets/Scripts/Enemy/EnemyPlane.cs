using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    [Header("Enemy Properties")]
    public float Speed;
    public float Health;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        Damage = Random.Range(Damage / 5, Damage);
        Speed = Random.Range(Speed / 2, Speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if (Health <= 0)
            Die();
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
    }

    public void Die()
    {
        Destroy(gameObject);
        UIManager.ScoreCount += 10;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("AA Shell"))
        {
            Health -= collision.GetComponent<ATShell>().Damage;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Crossing Line"))
        {
            collision.transform.GetComponent<CrossingLine>().GetBombed(Damage);

            Destroy(collision.gameObject, 2f);
        }
    }
}
