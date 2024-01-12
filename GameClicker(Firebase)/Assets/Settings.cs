using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider volumeBackgroundAudioSlider;
    [SerializeField] private Slider volumeEffectsAudioSlider;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI textVolumeBackground;
    [SerializeField] private TextMeshProUGUI textVolumeEffects;

    private SettingsInteractor settingsInteractor;

    public void Initialize()
    {
        settingsInteractor = Game.GetInteractor<SettingsInteractor>();

        volumeBackgroundAudioSlider.value = settingsInteractor.volumeBackgroundAudioSource;
        volumeEffectsAudioSlider.value = settingsInteractor.volumeEffectsAudioSource;

        ChangeValueText(volumeBackgroundAudioSlider, textVolumeBackground);
        ChangeValueText(volumeEffectsAudioSlider, textVolumeEffects);

        volumeBackgroundAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeBackground(); });
        volumeEffectsAudioSlider.onValueChanged.AddListener(delegate { ChangeVolumeEffects(); });
    }

    private void OnDestroy()
    {
        volumeBackgroundAudioSlider.onValueChanged.RemoveListener(delegate { ChangeVolumeBackground(); });
        volumeEffectsAudioSlider.onValueChanged.RemoveListener(delegate { ChangeVolumeEffects(); });

        settingsInteractor.ApplyChanges();
    }

    private void ChangeVolumeBackground()
    {
        settingsInteractor.ChangeVolumeBackgroundSound(this.name, volumeBackgroundAudioSlider.value);
        ChangeValueText(volumeBackgroundAudioSlider, textVolumeBackground);
    }

    private void ChangeVolumeEffects()
    {
        settingsInteractor.ChangeVolumeEffectsSound(this.name, volumeEffectsAudioSlider.value);
        ChangeValueText(volumeEffectsAudioSlider, textVolumeEffects);
    }

    private void ChangeValueText(Slider slider, TextMeshProUGUI text)
    {
        text.text = Mathf.Round(slider.value * 100).ToString();
    }
}
