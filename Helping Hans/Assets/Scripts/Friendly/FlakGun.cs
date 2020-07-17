using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlakGun : MonoBehaviour
{
    public GameObject Target;
    public string TargetTag;

    [Header("Unit Properties")]
    public float Ammo;
    public float Range;
    public float RPM;
    public float ReloadTime;

    [Header("Runtime Properties")]
    public float CurrentAmmo;
    public float CurrentRPM;
    public float CurrentReloadTime;

    [Header("Unit Components")]
    public GameObject AmmunitionType;
    public Bunker AmmunitionHolder;
    public GameObject MainGun;
    public GameObject FirePoint;
    public AudioSource FireSound;

    // Start is called before the first frame update
    void Start()
    {
        AmmunitionHolder = transform.parent.GetComponent<Bunker>();
        InvokeRepeating("Observing", 0f, 0.5f);

        CurrentReloadTime = Ammo;
        CurrentRPM = RPM;
        CurrentReloadTime = ReloadTime;
    }

    // Update is called once per frame
    void Update()
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

        if (CurrentAmmo <= 0)
        {
            Reloading();
        }
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

    void Aimming()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Target.transform.position - transform.position);
    }

    void Firing()
    {
        // Check if there is still have ammo
        if (CurrentAmmo > 0)
        {
            // Check for RPM
            if (CurrentRPM > 0)
                CurrentRPM -= Time.deltaTime;
            else
            {
                Instantiate(AmmunitionType, FirePoint.transform.position, FirePoint.transform.rotation);
                FireSound.Play();
                CurrentAmmo--;
                CurrentRPM = RPM;
            }
        }
    }

    private void Reloading()
    {
        if (AmmunitionHolder.AmmoBox > 0)
        {
            if (CurrentReloadTime > 0)
                CurrentReloadTime -= Time.deltaTime;
            else
            {
                CurrentAmmo = Ammo;
                AmmunitionHolder.AmmoBox--;
                CurrentReloadTime = ReloadTime;
            }
        }
        else
            return;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
