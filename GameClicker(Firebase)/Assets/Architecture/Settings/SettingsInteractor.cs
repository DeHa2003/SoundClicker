using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class SettingsInteractor : Interactor
    {
        //VOLUME_SOUNDS
        public float volumeBackgroundAudioSource { get; private set; }
        public float volumeEffectsAudioSource { get; private set; }

        public float pitchBass { get; private set; }
        public float pitchBass_2 { get; private set; }
        public float pitchTenorTom { get; private set; }
        public float pitchAltTom { get; private set; }
        public float pitchHayHet { get; private set; }
        public float pitchRide { get; private set; }
        public float pitchCrash { get; private set; }


        private AudioManager audioManager;

        private AudioVolumeRepository audioVolumeRepository;
        private PitchInstrumentsRepository pitchRepository;

        public override void Initialize()
        {
            base.Initialize();

            audioVolumeRepository = Game.GetRepository<AudioVolumeRepository>();
            pitchRepository = Game.GetRepository<PitchInstrumentsRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            this.volumeBackgroundAudioSource = audioVolumeRepository.volumeBackgroundAudioSource;
            this.volumeEffectsAudioSource = audioVolumeRepository.volumeEffectsAudioSource;

            this.pitchBass = pitchRepository.pitchBass;
            this.pitchBass_2 = pitchRepository.pitchBass_2;
            this.pitchTenorTom = pitchRepository.pitchTenorTom;
            this.pitchAltTom = pitchRepository.pitchAltTom;
            this.pitchHayHet = pitchRepository.pitchHayHet;
            this.pitchRide = pitchRepository.pitchRide;
            this.pitchCrash = pitchRepository.pitchCrash;
        }

        public void SetData(AudioManager audioManager)
        {
            this.audioManager = audioManager;
            audioManager.ChangeVolumeEffectsSound(this.volumeEffectsAudioSource);
            audioManager.ChangeVolumeBackgroundSound(this.volumeBackgroundAudioSource);
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

        public void ChangePitchBass(int value)
        {
            pitchBass = value;
        }
        public void ChangePitchBass_2(int value)
        {
            pitchBass_2 = value;
        }
        public void ChangePitchTenor(int value)
        {
            pitchTenorTom = value;
        }
        public void ChangePitchAlt(int value)
        {
            pitchAltTom = value;
        }
        public void ChangePitchHayHet(int value)
        {
            pitchHayHet = value;
        }
        public void ChangePitchRide(int value)
        {
            pitchRide = value;
        }
        public void ChangePitchCrash(int value)
        {
            pitchCrash = value;
        }

        public void Save()
        {
            audioVolumeRepository.volumeBackgroundAudioSource = volumeBackgroundAudioSource;
            audioVolumeRepository.volumeEffectsAudioSource = volumeEffectsAudioSource;
            audioVolumeRepository.Save();

            pitchRepository.pitchBass = pitchBass;
            pitchRepository.pitchBass_2 = pitchBass_2;
            pitchRepository.pitchTenorTom = pitchTenorTom;
            pitchRepository.pitchAltTom = pitchAltTom;
            pitchRepository.pitchHayHet = pitchHayHet;
            pitchRepository.pitchRide = pitchRide;
            pitchRepository.pitchCrash = pitchCrash;

            pitchRepository.Save();
        }

    }
}
