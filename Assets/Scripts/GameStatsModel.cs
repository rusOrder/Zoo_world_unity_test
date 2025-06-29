using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsModel
{
    public int DeadPreyCount { get; set; }
    public int DeadPredatorCount { get; set; }

    public void Reset()
    {
        DeadPreyCount = 0;
        DeadPredatorCount = 0;
    }
}
