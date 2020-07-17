using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingLine : MonoBehaviour
{
    public RadioStation RadioStation;

    public void GetBombed(float Damage)
    {
        RadioStation.SupplyRoadStatus -= Damage;
    }
}
