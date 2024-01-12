using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISongData
{
    int SongID { get; }
    string SongName { get; }
    string SongDescription { get; }
    AudioClip AudioClip { get; }
    Sprite BackgroundImage { get; }
}

[CreateAssetMenu(fileName = "NewSongData", menuName = "Song Data")]
public class SongData : ScriptableObject, ISongData
{

    [SerializeField] private int songID;
    [SerializeField] private Sprite backgrondImage;
    [SerializeField] private string songName;
    [SerializeField] private string songDescription;
    [SerializeField] private AudioClip clip;

    public int SongID => songID;
    public string SongName => songName;
    public Sprite BackgroundImage => backgrondImage;
    public AudioClip AudioClip => clip;
    public string SongDescription => songDescription;
}
