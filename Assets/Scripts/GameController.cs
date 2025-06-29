using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private float _spawnRadius = 5f;

    [Inject] private IAnimalFactory _animalFactory;
    [Inject] private IGameStatsViewModel _statsViewModel;

    private float _spawnTimer;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer >= _spawnInterval)
        {
            SpawnRandomAnimal();
            _spawnTimer = 0f;
        }
    }

    private void SpawnRandomAnimal()
    {
        var spawnPosition = Random.insideUnitCircle * _spawnRadius;
        var position = new Vector3(spawnPosition.x, 0, spawnPosition.y);

        if (Random.value > 0.5f)
            _animalFactory.CreateFrog(position);
        else
            _animalFactory.CreateSnake(position);
    }
}
