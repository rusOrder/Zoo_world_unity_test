using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AnimalModel
{
    public AnimalType Type { get; protected set; }
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public bool IsDead { get; set; }
    public event Action OnDeath;

    public void Die()
    {
        IsDead = true;
        OnDeath?.Invoke();
    }
}
