using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalViewModel
{
    AnimalType Type { get; }
    Vector3 Position { get; set; }
    Quaternion Rotation { get; set; }
    void Initialize(AnimalModel model);
    void Update();
    void HandleCollision(IAnimalViewModel other);
}
public abstract class AnimalViewModel : IAnimalViewModel
{
    protected AnimalModel _model;
    protected readonly IGameStatsViewModel _statsViewModel;

    public AnimalType Type => _model.Type;
    public Vector3 Position
    {
        get => _model.Position;
        set => _model.Position = value;
    }
    public Quaternion Rotation
    {
        get => _model.Rotation;
        set => _model.Rotation = value;
    }

    protected AnimalViewModel(IGameStatsViewModel statsViewModel)
    {
        _statsViewModel = statsViewModel;
    }

    public virtual void Initialize(AnimalModel model)
    {
        _model = model;
        _model.OnDeath += OnDeath;
    }

    public abstract void Update();

    public abstract void HandleCollision(IAnimalViewModel other);

    protected virtual void OnDeath()
    {
        if (_model.Type == AnimalType.Prey)
            _statsViewModel.IncrementDeadPrey();
        else
            _statsViewModel.IncrementDeadPredator();
    }
}
