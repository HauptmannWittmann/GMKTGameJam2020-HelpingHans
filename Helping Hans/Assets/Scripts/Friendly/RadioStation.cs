using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStation : MonoBehaviour
{
    [SerializeField] PlayerController player;
    float playerOriginalSpeed;

    [Header("Supply Information")]
    public float OriSupplyTime;
    public float SupplyTime;
    public float SupplyRoadStatus;
    public float SupplyRoadTemp;

    [SerializeField] bool isConfirm;
    public float CurrentSupplyTime;

    [Header("Level Conecter")]
    public GameObject SupplyZoneOne;
    public GameObject SupplyZoneTwo;
    public GameObject SupplyZoneThree;

    [Header("UI Conecter")]
    public GameObject RadioUI;
    public AmmunitionCrateDropdown SlotOne;
    public AmmunitionCrateDropdown Slottwo;
    public AmmunitionCrateDropdown SlotThree;

    private void Start()
    {
        isConfirm = false;
        CurrentSupplyTime = SupplyTime;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerOriginalSpeed = player.playerSpeed;
        SupplyRoadStatus = 100;
        SupplyRoadTemp = SupplyRoadStatus;
        SupplyTime = OriSupplyTime;

    }

    private void Update()
    {
        if (isConfirm)
            TransportSupply();

        if (RadioUI.activeSelf == true)
        {
            player.playerSpeed = 0;
        }
        else if (RadioUI.activeSelf == false)
        {
            player.playerSpeed = playerOriginalSpeed;
        }

        if (SupplyRoadStatus != SupplyRoadTemp)
        {
            SupplyTime = OriSupplyTime + (OriSupplyTime / 100 * (100 - SupplyRoadStatus));
            SupplyRoadTemp = SupplyRoadStatus;
        }
    }

    public void btn_Confirm()
    {
        isConfirm = true;
        RadioUI.SetActive(false);
    }

    private void TransportSupply()
    {
        if (CurrentSupplyTime > 0)
            CurrentSupplyTime -= Time.deltaTime;
        else
        {
            if (SlotOne.SelectedCrate != null)
                Instantiate(SlotOne.SelectedCrate, SupplyZoneOne.transform.position, SupplyZoneOne.transform.rotation);

            if (Slottwo.SelectedCrate != null)
                Instantiate(Slottwo.SelectedCrate, SupplyZoneTwo.transform.position, SupplyZoneTwo.transform.rotation);

            if (SlotThree.SelectedCrate != null)
                Instantiate(SlotThree.SelectedCrate, SupplyZoneThree.transform.position, SupplyZoneThree.transform.rotation);

            CurrentSupplyTime = SupplyTime;
            isConfirm = false;
        }
    }

    public void btn_Cancel()
    {
        RadioUI.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && Input.GetMouseButton(0))
        {
            RadioUI.SetActive(true);
        }
    }
}
