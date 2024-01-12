using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class SongInteractor : Interactor
    {
        public int SoundID { get; private set; }

        private SongControl songControl;
        private SongRepository songRepository;

        public override void Initialize()
        {
            base.Initialize();
            songRepository = Game.GetRepository<SongRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();
            SoundID = songRepository.SoundID;
        }

        public void SetSongController(SongControl songControl)
        {
            this.songControl = songControl;
        }

        public void SetSongID(int songID)
        {
            this.SoundID = songID;
            Save();
        }

        public void Play()
        {
            songControl.SetData(SoundID);
            songControl.Play();
        }

        public void Save()
        {
            songRepository.SetData(SoundID);
            songRepository.Save();
        }
    }
}
