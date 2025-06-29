using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStatsViewModel
{
    int DeadPreyCount { get; }
    int DeadPredatorCount { get; }
    void IncrementDeadPrey();
    void IncrementDeadPredator();
    void ResetStats();
}
