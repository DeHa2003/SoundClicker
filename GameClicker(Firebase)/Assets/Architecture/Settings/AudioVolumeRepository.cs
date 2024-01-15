using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lessons.Architecture
{
    public class AudioVolumeRepository : Repository
    {
        public float volumeBackgroundAudioSource;
        public float volumeEffectsAudioSource;
        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void Initialize()
        {
            if (File.Exists(Application.persistentDataPath + "/VolumeSounds.fun"))
            {
                VolumeSounds volumeSounds = GetSettingsData();
                volumeBackgroundAudioSource = volumeSounds.volumeBackgroundAudioSource;
                volumeEffectsAudioSource = volumeSounds.volumeEffectsAudioSource;
            }
            else
            {
                Save();
            }
        }

        public override void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/VolumeSounds.fun";
            FileStream stream = new FileStream(path, FileMode.Create);

            VolumeSounds settingsData = new(volumeBackgroundAudioSource, volumeEffectsAudioSource);

            binaryFormatter.Serialize(stream, settingsData);
            stream.Close();
        }

        public VolumeSounds GetSettingsData()
        {
            string path = Application.persistentDataPath + "/VolumeSounds.fun";
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                VolumeSounds settingsData = binaryFormatter.Deserialize(stream) as VolumeSounds;
                stream.Close();

                return settingsData;
            }
            else
            {
                Debug.Log("Save file not found in " + path);
                return null;
            }
        }
    }

    [System.Serializable]
    public class VolumeSounds
    {
        public float volumeBackgroundAudioSource { get; private set; }
        public float volumeEffectsAudioSource { get; private set; }

        public VolumeSounds(float volumeBackgroundAudio, float volumeEffectsAudioSource)
        {
            this.volumeBackgroundAudioSource = volumeBackgroundAudio;
            this.volumeEffectsAudioSource = volumeEffectsAudioSource;
        }
    }
}
