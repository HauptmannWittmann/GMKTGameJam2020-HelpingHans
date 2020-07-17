using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanner : MonoBehaviour
{
    public GameObject[] EnemyUnits;
    [Header("Spawning Time")]
    public bool isAttacking;
    public float AttackWaveCooldown;
    public float AttackWaveDuration;
    public float SpanCoolDown;

    [SerializeField] float CurrentAttackWaveCoolDown;
    [SerializeField] float CurrentAttackWaveDuration;
    [SerializeField] float CurrentSpanCoolDown;

    private void Update()
    {
        if (!isAttacking)
        {
            if (CurrentAttackWaveCoolDown > 0)
                CurrentAttackWaveCoolDown -= Time.deltaTime;
            else
            {
                isAttacking = true;
                CurrentAttackWaveCoolDown = AttackWaveCooldown;
            }
        }

        if (isAttacking)
        {
            if (CurrentAttackWaveDuration > 0)
            {
                if (CurrentSpanCoolDown > 0)
                    CurrentSpanCoolDown -= Time.deltaTime;
                else
                {
                    SpawnEnemy();
                    CurrentSpanCoolDown = SpanCoolDown;
                }

                CurrentAttackWaveDuration -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                CurrentAttackWaveDuration = AttackWaveDuration;
            }
        }
    }

    private void SpawnEnemy()
    {
        Vector3 fixPosition = new Vector3(Random.Range(-25f, 25f), transform.position.y, transform.position.z);

        Instantiate(EnemyUnits[Random.Range(0, EnemyUnits.Length)], fixPosition, transform.rotation);
    }
}
