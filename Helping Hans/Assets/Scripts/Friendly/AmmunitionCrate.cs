using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionCrate : MonoBehaviour
{
    public AmmunitionType crateAmmunitionType;
    public int crateAmmunitionSlot;
    public CrateState crateState;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            this.transform.SetParent(player.transform.parent);
            crateState = CrateState.isDrop;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Hiện ra UI rằng người chơi có thể cầm
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButton(0))
        {
            if (collision.transform.CompareTag("Player"))
            {
                if (crateState == CrateState.isDrop)
                {
                    transform.SetParent(collision.transform);
                    crateState = CrateState.isPick;
                }
            }
        }
        else 
        {
            if (collision.transform.CompareTag("Bunker"))
            {
                Bunker bunker = collision.GetComponent<Bunker>();

                if (bunker.AmmunitionType == crateAmmunitionType)
                {
                    bunker.AmmoBox += crateAmmunitionSlot;
                    Destroy(gameObject);
                }
            }
        }
    }
}
