using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lessons.Architecture
{
    public class PitchInstrumentsRepository :Repository
    {
        public float pitchBass;
        public float pitchBass_2;
        public float pitchTenorTom;
        public float pitchAltTom;
        public float pitchHayHet;
        public float pitchRide;
        public float pitchCrash;

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
                Save();
            }
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
        public float bass { get; private set; }
        public float bass_2 { get; private set; }
        public float tenorTom { get; private set; }
        public float altTom { get; private set; }
        public float hayHet { get; private set; }
        public float ride { get; private set; }
        public float crash { get; private set; }

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
