using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lessons.Architecture
{
    public class InstrumentsSettingsRepository :Repository
    {
        public float volumeBass { get; private set; }
        public float volumeBass_2 { get; private set; }
        public float volumeTenorTom { get; private set; }
        public float volumeAltTom { get; private set; }
        public float volumeHayHet { get; private set; }
        public float volumeRide { get; private set; }
        public float volumeCrash { get; private set; }

        public float pitchBass { get; private set; }
        public float pitchBass_2 { get; private set; }
        public float pitchTenorTom { get; private set; }
        public float pitchAltTom { get; private set; }
        public float pitchHayHet { get; private set; }
        public float pitchRide { get; private set; }
        public float pitchCrash { get; private set; }

        private const string pathData = "/InstrumentsSettings.fun";

        public override void Initialize()
        {
            if (File.Exists(Application.persistentDataPath + pathData))
            {
                PitchInstrumentsSounds pitchInstrumentsSounds = GetPitchInstruments();

                SetVolumeData(pitchInstrumentsSounds.volumeBass, pitchInstrumentsSounds.volumeBass_2, pitchInstrumentsSounds.volumeTenor, pitchInstrumentsSounds.volumeAlt, pitchInstrumentsSounds.volumeHayHet, pitchInstrumentsSounds.volumeRide, pitchInstrumentsSounds.volumeCrash);
                SetPitchData(pitchInstrumentsSounds.pitchBass, pitchInstrumentsSounds.pitchBass_2, pitchInstrumentsSounds.pitchTenor, pitchInstrumentsSounds.pitchAlt, pitchInstrumentsSounds.pitchHayHet, pitchInstrumentsSounds.pitchRide, pitchInstrumentsSounds.pitchCrash);

            }
            else
            {
                SetVolumeData(1, 1, 1, 1, 1, 1, 1);
                SetPitchData(1, 1, 1, 1, 1, 1, 1);

                Save();
            }
        }

        public void SetVolumeData(float bass, float bass2, float tenor, float alt, float hayHet, float ride, float crash)
        {
            this.volumeBass = bass;
            this.volumeBass_2 = bass2;
            this.volumeTenorTom = tenor;
            this.volumeAltTom = alt;
            this.volumeHayHet = hayHet;
            this.volumeRide = ride;
            this.volumeCrash = crash;
        }

        public void SetPitchData(float bass, float bass2, float tenor, float alt, float hayHet, float ride, float crash)
        {
            this.pitchBass = bass;
            this.pitchBass_2 = bass2;
            this.pitchTenorTom = tenor;
            this.pitchAltTom = alt;
            this.pitchHayHet = hayHet;
            this.pitchRide = ride;
            this.pitchCrash = crash;
        }

        public override void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + pathData;
            FileStream stream = new FileStream(path, FileMode.Create);

            PitchInstrumentsSounds pitchInstrumentsSounds = new PitchInstrumentsSounds();


            pitchInstrumentsSounds.SetVolumeData(volumeBass, volumeBass_2, volumeTenorTom, volumeAltTom, volumeHayHet, volumeRide, volumeCrash);
            pitchInstrumentsSounds.SetPitchData(pitchBass, pitchBass_2, pitchTenorTom, pitchAltTom, pitchHayHet, pitchRide, pitchCrash);


            binaryFormatter.Serialize(stream, pitchInstrumentsSounds);
            stream.Close();
        }

        public PitchInstrumentsSounds GetPitchInstruments()
        {
            string path = Application.persistentDataPath + pathData;
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PitchInstrumentsSounds settipitchInstrumentsData = binaryFormatter.Deserialize(stream) as PitchInstrumentsSounds;
                stream.Close();

                return settipitchInstrumentsData;
            }
            else
            {
                Debug.Log("Save file not found in " + path);
                return null;
            }
        }
    }

    [System.Serializable]
    public class PitchInstrumentsSounds
    {
        public float pitchBass;
        public float pitchBass_2;
        public float pitchTenor;
        public float pitchAlt;
        public float pitchHayHet;
        public float pitchRide;
        public float pitchCrash;

        public float volumeBass;
        public float volumeBass_2;
        public float volumeTenor;
        public float volumeAlt;
        public float volumeHayHet;
        public float volumeRide;
        public float volumeCrash;

        public void SetPitchData(float bass, float bass_2, float tenorTom, float altTom, float hayHet, float ride, float crash)
        {
            this.pitchBass = bass;
            this.pitchBass_2 = bass_2;
            this.pitchTenor = tenorTom;
            this.pitchAlt = altTom;
            this.pitchHayHet = hayHet;
            this.pitchRide = ride;
            this.pitchCrash = crash;
        }

        public void SetVolumeData(float bass, float bass_2, float tenorTom, float altTom, float hayHet, float ride, float crash)
        {
            this.volumeBass = bass;
            this.volumeBass_2 = bass_2;
            this.volumeTenor = tenorTom;
            this.volumeAlt = altTom;
            this.volumeHayHet = hayHet;
            this.volumeRide = ride;
            this.volumeCrash = crash;
        }
    }
}
