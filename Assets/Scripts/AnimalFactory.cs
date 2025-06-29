using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AnimalFactory : IAnimalFactory
{
    private readonly FrogViewModel.Factory _frogFactory;
    private readonly SnakeViewModel.Factory _snakeFactory;

    public AnimalFactory(
        FrogViewModel.Factory frogFactory,
        SnakeViewModel.Factory snakeFactory)
    {
        _frogFactory = frogFactory;
        _snakeFactory = snakeFactory;
    }

    public IAnimalViewModel CreateFrog(Vector3 position)
    {
        var model = new FrogModel { Position = position };
        return _frogFactory.Create(model);
    }

    public IAnimalViewModel CreateSnake(Vector3 position)
    {
        var model = new SnakeModel { Position = position };
        return _snakeFactory.Create(model);
    }
}
