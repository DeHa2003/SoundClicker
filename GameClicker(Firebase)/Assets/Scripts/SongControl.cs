using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SongControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI songName;
    [SerializeField] private Image backgroundPanel;
    [SerializeField] private AudioSource audio_m;
    [SerializeField] private SongData[] songs;

    private SongData songData;

    public void SetData(int soundID)
    {
        for (int i = 0; i < songs.Length; i++)
        {
            if (songs[i].SongID == soundID)
            {
                songData = songs[i];
            }
        }
        if(songData == null)
        {
            Debug.Log("Песня не найдена");
            return;
        }
        songName.text = songData.SongName;
        backgroundPanel.sprite = songData.BackgroundImage;
        audio_m.clip = songData.AudioClip;
        Play();
    }

    public void Play()
    {
        audio_m.Play();
    }
}
