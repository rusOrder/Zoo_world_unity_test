using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SnakeViewModel : AnimalViewModel
{
    private readonly float _moveSpeed;
    private Vector3 _currentDirection;
    private readonly ITextPopupViewModel _textPopupViewModel;

    public class Factory : IFactory<SnakeModel, SnakeViewModel>
    {
        private readonly IGameStatsViewModel _statsViewModel;
        private readonly ITextPopupViewModel _textPopupViewModel;

        public Factory(
            IGameStatsViewModel statsViewModel,
            ITextPopupViewModel textPopupViewModel)
        {
            _statsViewModel = statsViewModel;
            _textPopupViewModel = textPopupViewModel;
        }

        public SnakeViewModel Create(SnakeModel model)
        {
            return new SnakeViewModel(_statsViewModel, _textPopupViewModel, model);
        }
    }

    public SnakeViewModel(
        IGameStatsViewModel statsViewModel,
        ITextPopupViewModel textPopupViewModel,
        SnakeModel model)
        : base(statsViewModel)
    {
        _moveSpeed = model.MoveSpeed;
        _textPopupViewModel = textPopupViewModel;
        Initialize(model);

        (_model as SnakeModel).OnAteSomething += () =>
            _textPopupViewModel.ShowPopup("Tasty!", Position);

        _currentDirection = new Vector3(
            UnityEngine.Random.Range(-1f, 1f),
            0,
            UnityEngine.Random.Range(-1f, 1f)
        ).normalized;
    }

    public override void Update()
    {
        Position += _currentDirection * _moveSpeed * Time.deltaTime;
    }

    public override void HandleCollision(IAnimalViewModel other)
    {
        (_model as SnakeModel).AteSomething();

        if (other.Type == AnimalType.Predator)
        {
            // 50% шанс что эта змея умрет
            if (UnityEngine.Random.value > 0.5f)
            {
                _model.Die();
            }
            else
            {
                other.HandleCollision(this);
            }
        }
        else
        {
            other.HandleCollision(this);
        }
    }
}