using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "MainScene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<FirebaseAuthenticationInteractor>(interactorsMap);

        CreateInteractor<GeneralSettingsInteractor>(interactorsMap);
        CreateInteractor<InstrumentsSettingsInteractor>(interactorsMap);

        CreateInteractor<AudioInteractor>(interactorsMap);
        CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        CreateInteractor<SongInteractor>(interactorsMap);
        CreateInteractor<UserInteractor>(interactorsMap);
        CreateInteractor<ScoreInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<GeneralSettingsRepository>(repositoriesMap);
        CreateRepository<InstrumentsSettingsRepository>(repositoriesMap);

        CreateRepository<SongRepository>(repositoriesMap);
        CreateRepository<ScoreRepository>(repositoriesMap);
        CreateRepository<UserRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
