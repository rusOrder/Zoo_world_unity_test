using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FrogViewModel : AnimalViewModel
{
    private float _jumpTimer;
    private readonly float _jumpForce;
    private readonly float _jumpInterval;
    public class Factory : IFactory<FrogModel, FrogViewModel>
    {
        private readonly IGameStatsViewModel _statsViewModel;

        public Factory(IGameStatsViewModel statsViewModel)
        {
            _statsViewModel = statsViewModel;
        }

        public FrogViewModel Create(FrogModel model)
        {
            return new FrogViewModel(_statsViewModel, model);
        }
    }

    public FrogViewModel(IGameStatsViewModel statsViewModel, FrogModel model)
        : base(statsViewModel)
    {
        _jumpForce = model.JumpForce;
        _jumpInterval = model.JumpInterval;
        Initialize(model);
    }

    public override void Update()
    {
        _jumpTimer += Time.deltaTime;
        if (_jumpTimer >= _jumpInterval)
        {
            Jump();
            _jumpTimer = 0f;
        }
    }

    private void Jump()
    {
        // Реализация прыжка
        var randomDirection = new Vector3(
            UnityEngine.Random.Range(-1f, 1f),
            0,
            UnityEngine.Random.Range(-1f, 1f)
        ).normalized;

        Position += randomDirection * _jumpForce;
    }

    public override void HandleCollision(IAnimalViewModel other)
    {
        if (other.Type == AnimalType.Predator)
        {
            _model.Die();
        }
    }
}
