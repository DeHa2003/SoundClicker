using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

    public class StartSceneConfig : SceneConfig
    {
    public const string SCENE_NAME = "StartScene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<FirebaseAuthenticationInteractor>(interactorsMap);

        CreateInteractor<GeneralSettingsInteractor>(interactorsMap);
        CreateInteractor<InstrumentsSettingsInteractor>(interactorsMap);

        CreateInteractor<AudioInteractor>(interactorsMap);
        CreateInteractor<NotificationInteractor>(interactorsMap);
        CreateInteractor<ScoreInteractor>(interactorsMap);
        CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        CreateInteractor<WordRandomizerInteractor>(interactorsMap);
        CreateInteractor<UserInteractor>(interactorsMap);
        CreateInteractor<SongInteractor>(interactorsMap);
        //CreateInteractor<ShopInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<GeneralSettingsRepository>(repositoriesMap);
        CreateRepository<InstrumentsSettingsRepository>(repositoriesMap);

        CreateRepository<UserRepository>(repositoriesMap);
        CreateRepository<ScoreRepository>(repositoriesMap);
        CreateRepository<SongRepository>(repositoriesMap);
        //CreateRepository<ShopRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
