using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private Sound bass;
    [SerializeField] private Sound bass_2;
    [SerializeField] private Sound tenorTom;
    [SerializeField] private Sound altTom;
    [SerializeField] private Sound hayHet;
    [SerializeField] private Sound ride;
    [SerializeField] private Sound crash;

    private SettingsInteractor settingsInteractor;

    public void Initialize()
    {
        settingsInteractor = Game.GetInteractor<SettingsInteractor>();

        SetData();
        InitializeInstruments();
    }

    private void SetData()
    {
        bass.SetData(settingsInteractor.pitchBass);
        bass_2.SetData(settingsInteractor.pitchBass_2);
        tenorTom.SetData(settingsInteractor.pitchTenorTom);
        altTom.SetData(settingsInteractor.pitchAltTom);
        hayHet.SetData(settingsInteractor.pitchHayHet);
        ride.SetData(settingsInteractor.pitchRide);
        crash.SetData(settingsInteractor.pitchCrash);
    }

    private void InitializeInstruments()
    {
        bass.Initialize();
        bass_2.Initialize();
        tenorTom.Initialize();
        altTom.Initialize();
        hayHet.Initialize();
        ride.Initialize();
        crash.Initialize();
    }
}
