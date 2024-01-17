using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lessons.Architecture
{
    public class PitchInstrumentsRepository :Repository
    {
        public float pitchBass { get; private set; }
        public float pitchBass_2 { get; private set; }
        public float pitchTenorTom { get; private set; }
        public float pitchAltTom { get; private set; }
        public float pitchHayHet { get; private set; }
        public float pitchRide { get; private set; }
        public float pitchCrash { get; private set; }

        public override void Initialize()
        {
            if (File.Exists(Application.persistentDataPath + "/PitchInstruments.fun"))
            {
                PitchInstrumentsSounds pitchInstrumentsSounds = GetPitchInstruments();

                pitchBass = pitchInstrumentsSounds.bass;
                pitchBass_2 = pitchInstrumentsSounds.bass_2;
                pitchTenorTom = pitchInstrumentsSounds.tenorTom;
                pitchAltTom = pitchInstrumentsSounds.altTom;
                pitchHayHet = pitchInstrumentsSounds.hayHet;
                pitchRide = pitchInstrumentsSounds.ride;
                pitchCrash = pitchInstrumentsSounds.crash;
            }
            else
            {
                pitchBass = 1;
                pitchBass_2 = 1;
                pitchTenorTom = 1;
                pitchAltTom = 1.3f;
                pitchHayHet = 1;
                pitchRide = 1;
                pitchCrash = 1;
                Save();
            }
        }

        public void SetData(float bass, float bass2, float tenor, float alt, float hayHet, float ride, float crash)
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
            string path = Application.persistentDataPath + "/PitchInstruments.fun";
            FileStream stream = new FileStream(path, FileMode.Create);

            PitchInstrumentsSounds pitchInstrumentsSounds = new(pitchBass, pitchBass_2, pitchTenorTom, pitchAltTom, pitchHayHet, pitchRide, pitchCrash);

            binaryFormatter.Serialize(stream, pitchInstrumentsSounds);
            stream.Close();
        }

        public PitchInstrumentsSounds GetPitchInstruments()
        {
            string path = Application.persistentDataPath + "/PitchInstruments.fun";
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
        public float bass;
        public float bass_2;
        public float tenorTom;
        public float altTom;
        public float hayHet;
        public float ride;
        public float crash;

        public PitchInstrumentsSounds(float bass, float bass_2, float tenorTom, float altTom, float hayHet, float ride, float crash)
        {
            this.bass = bass;
            this.bass_2 = bass_2;
            this.tenorTom = tenorTom;
            this.altTom = altTom;
            this.hayHet = hayHet;
            this.ride = ride;
            this.crash = crash;
        }
    }
}
