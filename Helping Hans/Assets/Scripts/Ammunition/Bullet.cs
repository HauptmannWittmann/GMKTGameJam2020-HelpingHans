using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Properties")]
    public float Speed = 50f;
    public float Damage = 10f;

    float bulletLiveTime = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        bulletLiveTime -= Time.deltaTime;

        if (bulletLiveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
