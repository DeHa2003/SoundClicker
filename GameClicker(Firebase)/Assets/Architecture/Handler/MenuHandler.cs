using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MenuHandler : Handler
{
    [SerializeField] private UserData userData;
    [SerializeField] private FirebaseGlobalEvents globalEvents;
    [SerializeField] private MenuInputData inputData;

    protected override void Awake()
    {
        base.Awake();

        StartCoroutine(LoadGame_Coroutine());
    }

    protected override void OnGameInitialized()
    {
        userData.Initialize();
        inputData.Initialize();
        globalEvents.Initialize();
        base.OnGameInitialized();
    }

    private IEnumerator LoadGame_Coroutine()
    {
        var task = FirebaseApp.CheckAndFixDependenciesAsync();

        yield return new WaitUntil(predicate: () => task.IsCompleted);

        if (task.IsFaulted)
        {
            Debug.Log("ERROR");
        }

        if (task.IsCompleted)
        {
            Game.Run(new StartSceneManager());
            base.Awake();
        }
    }
}
