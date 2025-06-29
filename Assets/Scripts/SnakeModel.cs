using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakeModel : AnimalModel
{
    public float MoveSpeed { get; } = 3f;
    public event Action OnAteSomething;

    public SnakeModel()
    {
        Type = AnimalType.Predator;
    }

    public void AteSomething()
    {
        OnAteSomething?.Invoke();
    }
}
