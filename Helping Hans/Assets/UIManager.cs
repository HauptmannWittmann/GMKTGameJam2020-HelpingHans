using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text WallHP;
    public Text SuppyRoadStatus;
    public Text Score;
    public Text TimeTillReinforce;

    public RadioStation RadioStation;
    public BunkerGate BunkerGate;

    public static int ScoreCount;

    private void Start()
    {
        ScoreCount = 0;
    }

    private void Update()
    {
        WallHP.text = "Wall HP: " + BunkerGate.GateHealth.ToString();
        SuppyRoadStatus.text = "Supply Road Status: " + RadioStation.SupplyRoadStatus.ToString();
        Score.text = "Score: " + int.Parse(ScoreCount.ToString());
        TimeTillReinforce.text = "Time till supply: " + RadioStation.CurrentSupplyTime.ToString();
    }
}
