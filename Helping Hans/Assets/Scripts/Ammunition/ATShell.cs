using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATShell : MonoBehaviour
{
    [Header("AT shell Properties")]
    public float Speed = 70f;
    public float Damage = 100f;

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
