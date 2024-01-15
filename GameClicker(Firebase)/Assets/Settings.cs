using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Volumes")]
    [SerializeField] private Slider volumeBackgroundAudioSlider;
    [SerializeField] private Slider volumeEffectsAudioSlider;
    [Header("Pitch instruments")]
    [SerializeField] private Slider pitchBassSlider;
    [SerializeField] private Slider pitchBass_2Slider;
    [SerializeField] private Slider pitchTenorTomSlider;
    [SerializeField] private Slider pitchAltTomSlider;
    [SerializeField] private Slider pitchHayHetSlider;
    [SerializeField] private Slider pitchRideSlider;
    [SerializeField] private Slider pitchCrashSlider;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI textVolumeBackground;
    [SerializeField] private TextMeshProUGUI textVolumeEffects;

    [SerializeField] private TextMeshProUGUI pitchBassText;
    [SerializeField] private TextMeshProUGUI pitchBass_2Text;
    [SerializeField] private TextMeshProUGUI pitchTenorTomText;
    [SerializeField] private TextMeshProUGUI pitchAltTomText;
    [SerializeField] private TextMeshProUGUI pitchHayHetText;
    [SerializeField] private TextMeshProUGUI pitchRideText;
    [SerializeField] private TextMeshProUGUI pitchCrashText;

    private SettingsInteractor settingsInteractor;

    public void Initialize()
    {
        settingsInteractor = Game.GetInteractor<SettingsInteractor>();


        volumeBackgroundAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeBackground(); });
        volumeEffectsAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeEffects(); });

        pitchBassSlider.onValueChanged.AddListener(delegate { ChangePitchBass(); });
        pitchBass_2Slider.onValueChanged.AddListener(delegate { ChangePitchBass_2(); });
        pitchTenorTomSlider.onValueChanged.AddListener(delegate { ChangePitchTenor(); });
        pitchAltTomSlider.onValueChanged.AddListener(delegate { ChangePitchAlt(); });
        pitchHayHetSlider.onValueChanged.AddListener(delegate { ChangePitchHayHet(); });
        pitchRideSlider.onValueChanged.AddListener(delegate { ChangePitchRide(); });
        pitchCrashSlider.onValueChanged.AddListener(delegate { ChangePitchCrash(); });

        VisualizeVolumeSounds();
        VisualizePitchInstruments();
    }

    private void OnDestroy()
    {
        volumeBackgroundAudioSlider.onValueChanged.RemoveListener(delegate { ChangeVolumeBackground(); });
        volumeEffectsAudioSlider.onValueChanged.RemoveListener(delegate { ChangeVolumeEffects(); });

        pitchBassSlider.onValueChanged.RemoveListener(delegate { ChangePitchBass(); });
        pitchBass_2Slider.onValueChanged.RemoveListener(delegate { ChangePitchBass_2(); });
        pitchTenorTomSlider.onValueChanged.RemoveListener(delegate { ChangePitchTenor(); });
        pitchAltTomSlider.onValueChanged.RemoveListener(delegate { ChangePitchAlt(); });
        pitchHayHetSlider.onValueChanged.RemoveListener(delegate { ChangePitchHayHet(); });
        pitchRideSlider.onValueChanged.RemoveListener(delegate { ChangePitchRide(); });
        pitchCrashSlider.onValueChanged.RemoveListener(delegate { ChangePitchCrash(); });

        settingsInteractor.Save();
    }

    private void VisualizeVolumeSounds()
    {
        volumeBackgroundAudioSlider.value = settingsInteractor.volumeBackgroundAudioSource;
        volumeEffectsAudioSlider.value = settingsInteractor.volumeEffectsAudioSource;

        TextProcent(volumeBackgroundAudioSlider, textVolumeBackground);
        TextProcent(volumeEffectsAudioSlider, textVolumeEffects);
    }

    private void VisualizePitchInstruments()
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



    private void ChangeVolumeBackground()
    {
        settingsInteractor.ChangeVolumeBackgroundSound(this.name, volumeBackgroundAudioSlider.value);
        TextProcent(volumeBackgroundAudioSlider, textVolumeBackground);
    }

    private void ChangeVolumeEffects()
    {
        settingsInteractor.ChangeVolumeEffectsSound(this.name, volumeEffectsAudioSlider.value);
        TextProcent(volumeEffectsAudioSlider, textVolumeEffects);
    }




    private void ChangePitchBass()
    {
        settingsInteractor.ChangePitchBass(pitchBassSlider.value);
        TextFloat(pitchBassSlider, pitchBassText);
    }

    private void ChangePitchBass_2()
    {
        settingsInteractor.ChangePitchBass_2(pitchBass_2Slider.value);
        TextFloat(pitchBass_2Slider, pitchBass_2Text);
    }

    private void ChangePitchTenor()
    {
        settingsInteractor.ChangePitchTenor(pitchTenorTomSlider.value);
        TextFloat(pitchTenorTomSlider, pitchTenorTomText);
    }

    private void ChangePitchAlt()
    {
        settingsInteractor.ChangePitchAlt(pitchAltTomSlider.value);
        TextFloat(pitchAltTomSlider, pitchAltTomText);
    }

    private void ChangePitchHayHet()
    {
        settingsInteractor.ChangePitchHayHet(pitchHayHetSlider.value);
        TextFloat(pitchHayHetSlider, pitchHayHetText);
    }

    private void ChangePitchRide()
    {
        settingsInteractor.ChangePitchRide(pitchRideSlider.value);
        TextFloat(pitchRideSlider, pitchRideText);
    }

    private void ChangePitchCrash()
    {
        settingsInteractor.ChangePitchCrash(pitchCrashSlider.value);
        TextFloat(pitchCrashSlider, pitchCrashText);
    }

    private void TextProcent(Slider slider, TextMeshProUGUI text)
    {
        text.text = Mathf.Round(slider.value * 100).ToString();
    }

    private void TextFloat(Slider slider, TextMeshProUGUI text)
    {
        text.text = Math.Round(slider.value, 2).ToString();
    }
}
