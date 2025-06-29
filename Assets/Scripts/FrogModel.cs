using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FrogModel : AnimalModel
{
    public float JumpForce { get; } = 5f;
    public float JumpInterval { get; } = 2f;

    public FrogModel()
    {
        Type = AnimalType.Prey;
    }
}
