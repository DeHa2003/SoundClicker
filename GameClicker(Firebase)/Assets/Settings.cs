using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GeneralSettings generalSettings;
    [SerializeField] private InstrumentsSettings instrumentsSettings;

    public void Initialize()
    {
        generalSettings.Initialize();
        instrumentsSettings.Initialize();

        VizualizeData();
    }

    private void VizualizeData()
    {
        generalSettings.VisualizeData();
        instrumentsSettings.VisualizeData();
    }

    private void OnDestroy()
    {
        generalSettings.SaveGeneralSettings();
        instrumentsSettings.SaveInstrumentsSettings();
    }
}

[Serializable]
public class InstrumentsSettings
{
    [Header("Volume sliders")]
    [SerializeField] private Slider volumeBassSlider;
    [SerializeField] private Slider volumeBass_2Slider;
    [SerializeField] private Slider volumeTenorTomSlider;
    [SerializeField] private Slider volumeAltTomSlider;
    [SerializeField] private Slider volumeHayHetSlider;
    [SerializeField] private Slider volumeRideSlider;
    [SerializeField] private Slider volumeCrashSlider;
    
    [Header("Pitch sliders")]
    [SerializeField] private Slider pitchBassSlider;
    [SerializeField] private Slider pitchBass_2Slider;
    [SerializeField] private Slider pitchTenorTomSlider;
    [SerializeField] private Slider pitchAltTomSlider;
    [SerializeField] private Slider pitchHayHetSlider;
    [SerializeField] private Slider pitchRideSlider;
    [SerializeField] private Slider pitchCrashSlider;

    [Header("Volume texts")]
    [SerializeField] private TextMeshProUGUI volumeBassTextMesh;
    [SerializeField] private TextMeshProUGUI volumeBass_2TextMesh;
    [SerializeField] private TextMeshProUGUI volumeTenorTomTextMesh;
    [SerializeField] private TextMeshProUGUI volumeAltTomTextMesh;
    [SerializeField] private TextMeshProUGUI volumeHayHetTextMesh;
    [SerializeField] private TextMeshProUGUI volumeRideTextMesh;
    [SerializeField] private TextMeshProUGUI volumeCrashTextMesh;

    [Header("Pitch texts")]
    [SerializeField] private TextMeshProUGUI pitchBassTextMesh;
    [SerializeField] private TextMeshProUGUI pitchBass_2TextMesh;
    [SerializeField] private TextMeshProUGUI pitchTenorTomTextMesh;
    [SerializeField] private TextMeshProUGUI pitchAltTomTextMesh;
    [SerializeField] private TextMeshProUGUI pitchHayHetTextMesh;
    [SerializeField] private TextMeshProUGUI pitchRideTextMesh;
    [SerializeField] private TextMeshProUGUI pitchCrashTextMesh;


    private InstrumentsSettingsInteractor instrumentsSettingsInteractor;

    public void Initialize()
    {
        instrumentsSettingsInteractor = Game.GetInteractor<InstrumentsSettingsInteractor>();




        volumeBassSlider.onValueChanged.AddListener(delegate
        {
            TextProcent(volumeBassSlider, volumeBassTextMesh);
            instrumentsSettingsInteractor.ChangeVolumeBass(volumeBassSlider.value);
        });

        volumeBass_2Slider.onValueChanged.AddListener(delegate
        {
            TextProcent(volumeBass_2Slider, volumeBass_2TextMesh);
            instrumentsSettingsInteractor.ChangeVolumeBass_2(volumeBass_2Slider.value);
        });

        volumeTenorTomSlider.onValueChanged.AddListener(delegate
        {
            TextProcent(volumeTenorTomSlider, volumeTenorTomTextMesh);
            instrumentsSettingsInteractor.ChangeVolumeTenor(volumeTenorTomSlider.value);
        });

        volumeAltTomSlider.onValueChanged.AddListener(delegate
        {
            TextProcent(volumeAltTomSlider, volumeAltTomTextMesh);
            instrumentsSettingsInteractor.ChangeVolumeAlt(volumeAltTomSlider.value);
        });

        volumeHayHetSlider.onValueChanged.AddListener(delegate
        {
            TextProcent(volumeHayHetSlider, volumeHayHetTextMesh);
            instrumentsSettingsInteractor.ChangeVolumeHayHet(volumeHayHetSlider.value);
        });

        volumeRideSlider.onValueChanged.AddListener(delegate
        {
            TextProcent(volumeRideSlider, volumeRideTextMesh);
            instrumentsSettingsInteractor.ChangeVolumeRide(volumeRideSlider.value);
        });

        volumeCrashSlider.onValueChanged.AddListener(delegate
        {
            TextProcent(volumeCrashSlider, volumeCrashTextMesh);
            instrumentsSettingsInteractor.ChangeVolumeCrash(volumeCrashSlider.value);
        });






        pitchBassSlider.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchBassSlider, pitchBassTextMesh);
            instrumentsSettingsInteractor.ChangePitchBass(pitchBassSlider.value);
        });

        pitchBass_2Slider.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchBass_2Slider, pitchBass_2TextMesh);
            instrumentsSettingsInteractor.ChangePitchBass_2(pitchBass_2Slider.value);
        });

        pitchTenorTomSlider.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchTenorTomSlider, pitchTenorTomTextMesh);
            instrumentsSettingsInteractor.ChangePitchTenor(pitchTenorTomSlider.value);
        });

        pitchAltTomSlider.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchAltTomSlider, pitchAltTomTextMesh);
            instrumentsSettingsInteractor.ChangePitchAlt(pitchAltTomSlider.value);
        });

        pitchHayHetSlider.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchHayHetSlider, pitchHayHetTextMesh);
            instrumentsSettingsInteractor.ChangePitchHayHet(pitchHayHetSlider.value);
        });

        pitchRideSlider.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchRideSlider, pitchRideTextMesh);
            instrumentsSettingsInteractor.ChangePitchRide(pitchRideSlider.value);
        });

        pitchCrashSlider.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchCrashSlider, pitchCrashTextMesh);
            instrumentsSettingsInteractor.ChangePitchCrash(pitchCrashSlider.value);
        });
    }

    private void TextProcent(Slider slider, TextMeshProUGUI text)
    {
        text.text = Mathf.Round(slider.value * 100).ToString();
    }

    private void TextFloat(Slider slider, TextMeshProUGUI text)
    {
        text.text = Math.Round(slider.value, 2).ToString();
    }

    public void VisualizeData()
    {
        volumeBassSlider.value = instrumentsSettingsInteractor.volumeBass;
        volumeBass_2Slider.value = instrumentsSettingsInteractor.volumeBass_2;
        volumeTenorTomSlider.value = instrumentsSettingsInteractor.volumeTenorTom;
        volumeAltTomSlider.value = instrumentsSettingsInteractor.volumeAltTom;
        volumeHayHetSlider.value = instrumentsSettingsInteractor.volumeHayHet;
        volumeRideSlider.value = instrumentsSettingsInteractor.volumeRide;
        volumeCrashSlider.value = instrumentsSettingsInteractor.volumeCrash;


        pitchBassSlider.value = instrumentsSettingsInteractor.pitchBass;
        pitchBass_2Slider.value = instrumentsSettingsInteractor.pitchBass_2;
        pitchTenorTomSlider.value = instrumentsSettingsInteractor.pitchTenorTom;
        pitchAltTomSlider.value = instrumentsSettingsInteractor.pitchAltTom;
        pitchHayHetSlider.value = instrumentsSettingsInteractor.pitchHayHet;
        pitchRideSlider.value = instrumentsSettingsInteractor.pitchRide;
        pitchCrashSlider.value = instrumentsSettingsInteractor.pitchCrash;



        TextProcent(volumeBassSlider, volumeBassTextMesh);
        TextProcent(volumeBass_2Slider, volumeBass_2TextMesh);
        TextProcent(volumeTenorTomSlider, volumeTenorTomTextMesh);
        TextProcent(volumeAltTomSlider, volumeAltTomTextMesh);
        TextProcent(volumeHayHetSlider, volumeHayHetTextMesh);
        TextProcent(volumeRideSlider, volumeRideTextMesh);
        TextProcent(volumeCrashSlider, volumeCrashTextMesh);


        TextFloat(pitchBassSlider, pitchBassTextMesh);
        TextFloat(pitchBass_2Slider, pitchBass_2TextMesh);
        TextFloat(pitchAltTomSlider, pitchAltTomTextMesh);
        TextFloat(pitchTenorTomSlider, pitchTenorTomTextMesh);
        TextFloat(pitchHayHetSlider, pitchHayHetTextMesh);
        TextFloat(pitchRideSlider, pitchRideTextMesh);
        TextFloat(pitchCrashSlider, pitchCrashTextMesh);
    }

    public void SaveInstrumentsSettings()
    {
        instrumentsSettingsInteractor.SaveInstrumentsSettings();
    }
}

[Serializable]
public class GeneralSettings
{
    [Header("Volumes")]
    [SerializeField] private Slider volumeBackgroundAudioSlider;
    [SerializeField] private Slider volumeEffectsAudioSlider;
    [SerializeField] private Slider volumeNotificationSlider;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI textVolumeBackground;
    [SerializeField] private TextMeshProUGUI textVolumeEffects;
    [SerializeField] private TextMeshProUGUI textVolumeNotification;



    private GeneralSettingsInteractor settingsInteractor;

    public void Initialize()
    {
        settingsInteractor = Game.GetInteractor<GeneralSettingsInteractor>();

        volumeBackgroundAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeBackground(); });
        volumeEffectsAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeEffects(); });
        volumeNotificationSlider.onValueChanged.AddListener(delegate { ChangeVolumeNotification(); });

    }

    public void SaveGeneralSettings()
    {
        settingsInteractor.SaveGeneralSettings();
    }



    private void ChangeVolumeBackground()
    {
        settingsInteractor.ChangeVolumeBackgroundSound(this, volumeBackgroundAudioSlider.value);
        TextProcent(volumeBackgroundAudioSlider, textVolumeBackground);
    }

    private void ChangeVolumeEffects()
    {
        settingsInteractor.ChangeVolumeEffectsSound(this, volumeEffectsAudioSlider.value);
        TextProcent(volumeEffectsAudioSlider, textVolumeEffects);
    }

    private void ChangeVolumeNotification()
    {
        settingsInteractor.ChangeVolumeNotificationSound(this, volumeNotificationSlider.value);
        TextProcent(volumeNotificationSlider, textVolumeNotification);
    }




    private void TextProcent(Slider slider, TextMeshProUGUI text)
    {
        text.text = Mathf.Round(slider.value * 100).ToString();
    }

    public void VisualizeData()
    {
        volumeBackgroundAudioSlider.value = settingsInteractor.volumeBackgroundAudioSource;
        volumeEffectsAudioSlider.value = settingsInteractor.volumeEffectsAudioSource;
        volumeNotificationSlider.value = settingsInteractor.volumeNotificationAudioSource;

        TextProcent(volumeBackgroundAudioSlider, textVolumeBackground);
        TextProcent(volumeEffectsAudioSlider, textVolumeEffects);
        TextProcent(volumeNotificationSlider, textVolumeNotification);
    }
}
