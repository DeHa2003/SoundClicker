using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class SongGrid : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI textNameSong;

    private SongData songData;
    private DescriptionSongPanel descriptionSongPanel;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Select);
    }

    public void SetData(SongData songData, DescriptionSongPanel descriptionSongPanel)
    {
        this.songData = songData;
        this.descriptionSongPanel = descriptionSongPanel;
        backgroundImage.sprite = songData.BackgroundImage;
        textNameSong.text = songData.SongName;
    }

    private void Select()
    {
        descriptionSongPanel.gameObject.SetActive(true);
        descriptionSongPanel.SetData(songData);
    }
}
