using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class InstrumentsSettingsInteractor : Interactor
    {
        public float pitchBass { get; private set; }
        public float pitchBass_2 { get; private set; }
        public float pitchTenorTom { get; private set; }
        public float pitchAltTom { get; private set; }
        public float pitchHayHet { get; private set; }
        public float pitchRide { get; private set; }
        public float pitchCrash { get; private set; }

        public float volumeBass { get; private set; }
        public float volumeBass_2 { get; private set; }
        public float volumeTenorTom { get; private set; }
        public float volumeAltTom { get; private set; }
        public float volumeHayHet { get; private set; }
        public float volumeRide { get; private set; }
        public float volumeCrash { get; private set; }

        private InstrumentsSettingsRepository instrumentsRepository;

        public override void Initialize()
        {
            base.Initialize();

            instrumentsRepository = Game.GetRepository<InstrumentsSettingsRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            this.volumeBass = instrumentsRepository.volumeBass;
            this.volumeBass_2 = instrumentsRepository.volumeBass_2;
            this.volumeTenorTom = instrumentsRepository.volumeTenorTom;
            this.volumeAltTom = instrumentsRepository.volumeAltTom;
            this.volumeHayHet = instrumentsRepository.volumeHayHet;
            this.volumeRide = instrumentsRepository.volumeRide;
            this.volumeCrash = instrumentsRepository.volumeCrash;

            this.pitchBass = instrumentsRepository.pitchBass;
            this.pitchBass_2 = instrumentsRepository.pitchBass_2;
            this.pitchTenorTom = instrumentsRepository.pitchTenorTom;
            this.pitchAltTom = instrumentsRepository.pitchAltTom;
            this.pitchHayHet = instrumentsRepository.pitchHayHet;
            this.pitchRide = instrumentsRepository.pitchRide;
            this.pitchCrash = instrumentsRepository.pitchCrash;
        }


        public void ChangeVolumeBass(float value)
        {
            volumeBass = value;
        }
        public void ChangeVolumeBass_2(float value)
        {
            volumeBass_2 = value;
        }
        public void ChangeVolumeTenor(float value)
        {
            volumeTenorTom = value;
        }
        public void ChangeVolumeAlt(float value)
        {
            volumeAltTom = value;
        }
        public void ChangeVolumeHayHet(float value)
        {
            volumeHayHet = value;
        }
        public void ChangeVolumeRide(float value)
        {
            volumeRide = value;
        }
        public void ChangeVolumeCrash(float value)
        {
            volumeCrash = value;
        }



        public void ChangePitchBass(float value)
        {
            pitchBass = value;
        }
        public void ChangePitchBass_2(float value)
        {
            pitchBass_2 = value;
        }
        public void ChangePitchTenor(float value)
        {
            pitchTenorTom = value;
        }
        public void ChangePitchAlt(float value)
        {
            pitchAltTom = value;
        }
        public void ChangePitchHayHet(float value)
        {
            pitchHayHet = value;
        }
        public void ChangePitchRide(float value)
        {
            pitchRide = value;
        }
        public void ChangePitchCrash(float value)
        {
            pitchCrash = value;
        }

        public void SaveInstrumentsSettings()
        {
            instrumentsRepository.SetVolumeData(volumeBass, volumeBass_2, volumeTenorTom, volumeAltTom, volumeHayHet, volumeRide, volumeCrash);
            instrumentsRepository.SetPitchData(pitchBass, pitchBass_2, pitchTenorTom, pitchAltTom, pitchHayHet, pitchRide, pitchCrash);

            instrumentsRepository.Save();
        }

    }
}
