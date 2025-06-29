using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalFactory
{
    IAnimalViewModel CreateFrog(Vector3 position);
    IAnimalViewModel CreateSnake(Vector3 position);
}
