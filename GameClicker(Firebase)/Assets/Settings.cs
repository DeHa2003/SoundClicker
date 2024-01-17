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

        generalSettings.VisualizeVolumeSounds();
        instrumentsSettings.VisualizePitchInstruments();
    }

    private void OnDestroy()
    {
        generalSettings.SaveGeneralSettings();
        instrumentsSettings.SaveInstrumentsSettings();
    }
}

[Serializable]
public class InstrumentsSettings : IInstrumentsSettings
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI pitchBassTextMesh;
    [SerializeField] private TextMeshProUGUI pitchBass_2TextMesh;
    [SerializeField] private TextMeshProUGUI pitchTenorTomTextMesh;
    [SerializeField] private TextMeshProUGUI pitchAltTomTextMesh;
    [SerializeField] private TextMeshProUGUI pitchHayHetTextMesh;
    [SerializeField] private TextMeshProUGUI pitchRideTextMesh;
    [SerializeField] private TextMeshProUGUI pitchCrashTextMesh;

    [Header("Sliders")]
    [SerializeField] private Slider pitchBassSlider;
    [SerializeField] private Slider pitchBass_2Slider;
    [SerializeField] private Slider pitchTenorTomSlider;
    [SerializeField] private Slider pitchAltTomSlider;
    [SerializeField] private Slider pitchHayHetSlider;
    [SerializeField] private Slider pitchRideSlider;
    [SerializeField] private Slider pitchCrashSlider;

    public Slider pitchBass => pitchBassSlider;

    public Slider pitchBass_2 => pitchBass_2Slider;

    public Slider pitchTenorTom => pitchTenorTomSlider;

    public Slider pitchAltTom => pitchAltTomSlider;

    public Slider pitchHayHet => pitchHayHetSlider;

    public Slider pitchRide => pitchRideSlider;

    public Slider pitchCrash => pitchCrashSlider;

    public TextMeshProUGUI pitchBassText => pitchBassTextMesh;

    public TextMeshProUGUI pitchBass_2Text => pitchBass_2TextMesh;

    public TextMeshProUGUI pitchTenorTomText => pitchTenorTomTextMesh;

    public TextMeshProUGUI pitchAltTomText => pitchAltTomTextMesh;

    public TextMeshProUGUI pitchHayHetText => pitchHayHetTextMesh;

    public TextMeshProUGUI pitchRideText => pitchRideTextMesh;

    public TextMeshProUGUI pitchCrashText => pitchCrashTextMesh;



    private SettingsInteractor settingsInteractor;

    public void Initialize()
    {
        settingsInteractor = Game.GetInteractor<SettingsInteractor>();

        pitchBass.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchBass, pitchBassText);
            settingsInteractor.ChangePitchBass(pitchBass.value);
        });

        pitchBass_2.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchBass_2, pitchBass_2Text);
            settingsInteractor.ChangePitchBass_2(pitchBass_2.value);
        });

        pitchTenorTom.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchTenorTom, pitchTenorTomText);
            settingsInteractor.ChangePitchTenor(pitchTenorTom.value);
        });

        pitchAltTom.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchAltTom, pitchAltTomText);
            settingsInteractor.ChangePitchAlt(pitchAltTom.value);
        });

        pitchHayHet.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchHayHet, pitchHayHetText);
            settingsInteractor.ChangePitchHayHet(pitchHayHet.value);
        });

        pitchRide.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchRide, pitchRideText);
            settingsInteractor.ChangePitchRide(pitchRide.value);
        });

        pitchCrash.onValueChanged.AddListener(delegate
        {
            TextFloat(pitchCrash, pitchCrashText);
            settingsInteractor.ChangePitchCrash(pitchCrash.value);
        });
    }

    private void TextFloat(Slider slider, TextMeshProUGUI text)
    {
        text.text = Math.Round(slider.value, 2).ToString();
    }

    public void VisualizePitchInstruments()
    {
        pitchBassSlider.value = settingsInteractor.pitchBass;
        pitchBass_2Slider.value = settingsInteractor.pitchBass_2;
        pitchTenorTomSlider.value = settingsInteractor.pitchTenorTom;
        pitchAltTomSlider.value = settingsInteractor.pitchAltTom;
        pitchHayHetSlider.value = settingsInteractor.pitchHayHet;
        pitchRideSlider.value = settingsInteractor.pitchRide;
        pitchCrashSlider.value = settingsInteractor.pitchCrash;

        TextFloat(pitchBassSlider, pitchBassText);
        TextFloat(pitchBass_2Slider, pitchBass_2Text);
        TextFloat(pitchAltTomSlider, pitchAltTomText);
        TextFloat(pitchTenorTomSlider, pitchTenorTomText);
        TextFloat(pitchHayHetSlider, pitchHayHetText);
        TextFloat(pitchRideSlider, pitchRideText);
        TextFloat(pitchCrashSlider, pitchCrashText);
    }

    public void SaveInstrumentsSettings()
    {
        settingsInteractor.SaveInstrumentsSettings();
    }
}

[Serializable]
public class GeneralSettings : IGeneralSettings
{
    [Header("Volumes")]
    [SerializeField] private Slider volumeBackgroundAudioSlider;
    [SerializeField] private Slider volumeEffectsAudioSlider;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI textVolumeBackground;
    [SerializeField] private TextMeshProUGUI textVolumeEffects;

    public Slider volumeBackgroundSound => volumeBackgroundAudioSlider;

    public Slider volumeEffectsSounds => volumeEffectsAudioSlider;

    public TextMeshProUGUI volumeBackgroundText => textVolumeBackground;

    public TextMeshProUGUI volumeEffectsText => textVolumeEffects;



    private SettingsInteractor settingsInteractor;

    public void Initialize()
    {
        settingsInteractor = Game.GetInteractor<SettingsInteractor>();

        volumeBackgroundAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeBackground(); });
        volumeEffectsAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeEffects(); });

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

    private void TextProcent(Slider slider, TextMeshProUGUI text)
    {
        text.text = Mathf.Round(slider.value * 100).ToString();
    }

    public void VisualizeVolumeSounds()
    {
        volumeBackgroundAudioSlider.value = settingsInteractor.volumeBackgroundAudioSource;
        volumeEffectsAudioSlider.value = settingsInteractor.volumeEffectsAudioSource;

        TextProcent(volumeBackgroundAudioSlider, textVolumeBackground);
        TextProcent(volumeEffectsAudioSlider, textVolumeEffects);
    }
}



public interface IInstrumentsSettings
{
    public Slider pitchBass { get; }
    public Slider pitchBass_2 { get; }
    public Slider pitchTenorTom { get; }
    public Slider pitchAltTom { get; }
    public Slider pitchHayHet { get; }
    public Slider pitchRide { get; }
    public Slider pitchCrash { get; }

    public TextMeshProUGUI pitchBassText { get; }
    public TextMeshProUGUI pitchBass_2Text { get; }
    public TextMeshProUGUI pitchTenorTomText { get; }
    public TextMeshProUGUI pitchAltTomText { get; }
    public TextMeshProUGUI pitchHayHetText { get; }
    public TextMeshProUGUI pitchRideText { get; }
    public TextMeshProUGUI pitchCrashText { get; }
}
public interface IGeneralSettings
{
    public Slider volumeBackgroundSound { get; }
    public Slider volumeEffectsSounds { get; }

    public TextMeshProUGUI volumeBackgroundText { get; }
    public TextMeshProUGUI volumeEffectsText { get; }
}
