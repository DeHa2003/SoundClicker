using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : Handler
{
    [SerializeField] private GameInputData inputData;
    protected override void Awake()
    {
        Game.Run(new MainSceneManager());
        base.Awake();
    }

    protected override void OnGameInitialized()
    {
        inputData.Initialize();
        base.OnGameInitialized();
    }
}
