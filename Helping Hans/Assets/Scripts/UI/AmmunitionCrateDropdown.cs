using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionCrateDropdown : MonoBehaviour
{
    public Image img_CrateIcon;
    public Dropdown db_SelectCrate;

    public GameObject SelectedCrate;
    public GameObject[] AmmunitionCrates;

    private void Start()
    {
        img_CrateIcon = transform.Find("img_CrateIcon").GetComponent<Image>();
        db_SelectCrate = transform.Find("db_SelectCrate").GetComponent<Dropdown>();

        ChangeCrateIcon();
    }

    public void ChangeCrateIcon()
    {
        if (db_SelectCrate.value == 0)
        {
            img_CrateIcon.sprite = db_SelectCrate.options[0].image;
            SelectedCrate = AmmunitionCrates[0];
        }
        if (db_SelectCrate.value == 1)
        {
            img_CrateIcon.sprite = db_SelectCrate.options[1].image;
            SelectedCrate = AmmunitionCrates[1];
        }
        if (db_SelectCrate.value == 2)
        {
            img_CrateIcon.sprite = db_SelectCrate.options[2].image;
            SelectedCrate = AmmunitionCrates[2];
        }
    }
}
