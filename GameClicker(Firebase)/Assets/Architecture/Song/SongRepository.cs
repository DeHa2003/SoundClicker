using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class SongRepository : Repository
    {
        public int SoundID { get; private set; }

        private const string ID_SOUND_KEY = "SOUND ID";
        public override void Initialize()
        {
            SoundID = PlayerPrefs.GetInt(ID_SOUND_KEY, -1);
        }

        public void SetData(int value)
        {
            this.SoundID = value;
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(ID_SOUND_KEY, SoundID);
        }
    }
}
