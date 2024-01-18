using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class GeneralSettingsInteractor : Interactor
    {
        public float volumeBackgroundAudioSource { get; private set; }
        public float volumeEffectsAudioSource { get; private set; }
        public float volumeNotificationAudioSource { get; private set; }


        private AudioManager audioManager;

        private GeneralSettingsRepository generalSettingsRepository;

        public override void Initialize()
        {
            base.Initialize();

            generalSettingsRepository = Game.GetRepository<GeneralSettingsRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            this.volumeBackgroundAudioSource = generalSettingsRepository.volumeBackgroundAudioSource;
            this.volumeEffectsAudioSource = generalSettingsRepository.volumeEffectsAudioSource;
            this.volumeNotificationAudioSource = generalSettingsRepository.volumeNotificationAudioSource;
        }

        public void SetData(AudioManager audioManager)
        {
            this.audioManager = audioManager;

            audioManager.ChangeVolumeEffectsSound(this.volumeEffectsAudioSource);
            audioManager.ChangeVolumeBackgroundSound(this.volumeBackgroundAudioSource);
            audioManager.ChangeVolumeNotification(this.volumeNotificationAudioSource);
        }

        public void ChangeVolumeBackgroundSound(object sender, float value)
        {
            volumeBackgroundAudioSource = value;
            audioManager.ChangeVolumeBackgroundSound(value);
        }

        public void ChangeVolumeEffectsSound(object sender, float value)
        {
            volumeEffectsAudioSource = value;
            audioManager.ChangeVolumeEffectsSound(value);
        }

        public void ChangeVolumeNotificationSound(object sender, float value)
        {
            volumeNotificationAudioSource = value;
            audioManager.ChangeVolumeNotification(value);
        }

        public void SaveGeneralSettings()
        {
            generalSettingsRepository.SetData(volumeBackgroundAudioSource, volumeEffectsAudioSource, volumeNotificationAudioSource);
            generalSettingsRepository.Save();
        }
    }
}
