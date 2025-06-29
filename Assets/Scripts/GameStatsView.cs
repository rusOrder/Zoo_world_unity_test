using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class GameStatsView : MonoBehaviour
{
    [SerializeField] private Text _preyCountText;
    [SerializeField] private Text _predatorCountText;

    [Inject] private IGameStatsViewModel _statsViewModel;

    private void Update()
    {
        _preyCountText.text = $"Prey: {_statsViewModel.DeadPreyCount}";
        _predatorCountText.text = $"Predators: {_statsViewModel.DeadPredatorCount}";
    }
}
