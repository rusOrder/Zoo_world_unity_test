using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatsViewModel : IGameStatsViewModel
{
    private readonly GameStatsModel _model;

    public int DeadPreyCount => _model.DeadPreyCount;
    public int DeadPredatorCount => _model.DeadPredatorCount;

    public GameStatsViewModel(GameStatsModel model)
    {
        _model = model;
    }

    public void IncrementDeadPrey() => _model.DeadPreyCount++;
    public void IncrementDeadPredator() => _model.DeadPredatorCount++;
    public void ResetStats() => _model.Reset();
}
