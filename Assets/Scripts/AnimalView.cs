using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class AnimalView : MonoBehaviour
{
    [Inject]
    public IAnimalViewModel ViewModel { private get; set; }

    protected virtual void Start()
    {
        // Инициализация view на основе ViewModel
        transform.position = ViewModel.Position;
        transform.rotation = ViewModel.Rotation;
    }

    private void Update()
    {
        ViewModel.Update();
        transform.position = ViewModel.Position;
        transform.rotation = ViewModel.Rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var otherView = collision.gameObject.GetComponent<AnimalView>();
        if (otherView != null)
        {
            ViewModel.HandleCollision(otherView.ViewModel);
        }
    }
}
