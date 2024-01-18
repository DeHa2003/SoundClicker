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

    private InstrumentsSettingsInteractor instrumentsSettingsInteractor;

    public void Initialize()
    {
        instrumentsSettingsInteractor = Game.GetInteractor<InstrumentsSettingsInteractor>();

        SetData();
        InitializeInstruments();
    }

    private void SetData()
    {
        bass.SetData(instrumentsSettingsInteractor.pitchBass, instrumentsSettingsInteractor.volumeBass);
        bass_2.SetData(instrumentsSettingsInteractor.pitchBass_2, instrumentsSettingsInteractor.volumeBass_2);
        tenorTom.SetData(instrumentsSettingsInteractor.pitchTenorTom, instrumentsSettingsInteractor.volumeTenorTom);
        altTom.SetData(instrumentsSettingsInteractor.pitchAltTom, instrumentsSettingsInteractor.volumeAltTom);
        hayHet.SetData(instrumentsSettingsInteractor.pitchHayHet, instrumentsSettingsInteractor.volumeHayHet);
        ride.SetData(instrumentsSettingsInteractor.pitchRide, instrumentsSettingsInteractor.volumeRide);
        crash.SetData(instrumentsSettingsInteractor.pitchCrash, instrumentsSettingsInteractor.volumeCrash);
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
