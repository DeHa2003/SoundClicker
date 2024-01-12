using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Handler : MonoBehaviour
{
    [SerializeField] protected PanelsControl panelsControl;

    protected virtual void Awake()
    {
        Game.OnGameInitializedEvent += OnGameInitialized;
    }

    protected virtual void OnGameInitialized()
    {
        panelsControl.Initialize();
        Game.OnGameInitializedEvent -= OnGameInitialized;
    }
}

