using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DescriptionSongPanel : Panel
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI textNameSong;
    [SerializeField] private TextMeshProUGUI textDescriptionSong;

    private SongData songData;
    private SongInteractor songInteractor;
    public override void Initialize()
    {
        base.Initialize();
        songInteractor = Game.GetInteractor<SongInteractor>();
    }

    public void SetData(SongData songData)
    {
        this.songData = songData;
        backgroundImage.sprite = songData.BackgroundImage;
        textNameSong.text = songData.SongName;
        textDescriptionSong.text = songData.SongDescription;
        
    }

    public void Play()
    {
        songInteractor.SetSongID(songData.SongID);
    }
}
