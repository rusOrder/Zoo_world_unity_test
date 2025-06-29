using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameStatsView _statsView;
    [SerializeField] private TextPopupView _textPopupView;

    [SerializeField] private GameObject _frogPrefab;
    [SerializeField] private GameObject _snakePrefab;

    public override void InstallBindings()
    {
        // Модели
        Container.Bind<GameStatsModel>().AsSingle();

        // ViewModel
        Container.Bind<IGameStatsViewModel>().To<GameStatsViewModel>().AsSingle();
        Container.Bind<ITextPopupViewModel>().To<TextPopupViewModel>().AsSingle();

        // Фабрики ViewModel
        Container.Bind<FrogViewModel.Factory>().AsSingle();
        Container.Bind<SnakeViewModel.Factory>().AsSingle();

        // Главная фабрика животных
        Container.Bind<IAnimalFactory>().To<AnimalFactory>().AsSingle();

        // View
        Container.BindInstance(_statsView);
        Container.BindInstance(_textPopupView);

        Container.Bind<GameObject>().WithId("FrogPrefab").FromInstance(_frogPrefab);
        Container.Bind<GameObject>().WithId("SnakePrefab").FromInstance(_snakePrefab);
        Container.Bind<AnimalPrefabFactory>().AsSingle();
    }
}
