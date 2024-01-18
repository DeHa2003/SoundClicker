using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lessons.Architecture
{
    public class GeneralSettingsRepository : Repository
    {
        public float volumeBackgroundAudioSource { get; private set; }
        public float volumeEffectsAudioSource { get; private set; }
        public float volumeNotificationAudioSource { get; private set; }


        private const string pathData = "/AudioGeneralSettings.fun";


        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void Initialize()
        {
            if (File.Exists(Application.persistentDataPath + pathData))
            {
                VolumeSounds volumeSounds = GetSettingsData();

                SetData(volumeSounds.volumeBackgroundAudioSource, volumeSounds.volumeEffectsAudioSource, volumeSounds.volumeNotificationAudioSource);
            }
            else
            {
                SetData(1, 1, 0.5f);
                Save();
            }
        }

        public void SetData(float volumeBackground, float volumeEffects, float volumeNotification)
        {
            this.volumeBackgroundAudioSource = volumeBackground;
            this.volumeEffectsAudioSource = volumeEffects;
            this.volumeNotificationAudioSource = volumeNotification;
        }

        public override void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + pathData;
            FileStream stream = new FileStream(path, FileMode.Create);

            VolumeSounds settingsData = new(volumeBackgroundAudioSource, volumeEffectsAudioSource, volumeNotificationAudioSource);

            binaryFormatter.Serialize(stream, settingsData);
            stream.Close();
        }

        public VolumeSounds GetSettingsData()
        {
            string path = Application.persistentDataPath + pathData;
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

        public float volumeNotificationAudioSource { get; private set; }

        public VolumeSounds(float volumeBackgroundAudioSource, float volumeEffectsAudioSource, float volumeNotificationAudioSource)
        {
            this.volumeBackgroundAudioSource = volumeBackgroundAudioSource;
            this.volumeEffectsAudioSource = volumeEffectsAudioSource;
            this.volumeNotificationAudioSource = volumeNotificationAudioSource;
        }
    }
}
