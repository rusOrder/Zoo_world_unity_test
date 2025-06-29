using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnimalPrefabFactory
{
    private readonly DiContainer _container;
    private readonly GameObject _frogPrefab;
    private readonly GameObject _snakePrefab;

    public AnimalPrefabFactory(
        DiContainer container,
        [Inject(Id = "FrogPrefab")] GameObject frogPrefab,
        [Inject(Id = "SnakePrefab")] GameObject snakePrefab)
    {
        _container = container;
        _frogPrefab = frogPrefab;
        _snakePrefab = snakePrefab;
    }

    public GameObject CreateFrog(Vector3 position)
    {
        return _container.InstantiatePrefab(_frogPrefab, position, Quaternion.identity, null);
    }

    public GameObject CreateSnake(Vector3 position)
    {
        return _container.InstantiatePrefab(_snakePrefab, position, Quaternion.identity, null);
    }
}
