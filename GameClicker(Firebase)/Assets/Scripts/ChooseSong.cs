using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSong : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private SongGrid songGridPref;
    [SerializeField] private SongData[] songs;
    [SerializeField] private DescriptionSongPanel descriptionSongPanel;

    public void Initialize()
    {
        RenderInventory(songs);
    }

    public void RenderInventory(SongData[] items)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < items.Length; i++)
        {
            AddItem(items[i]);
        }
    }

    public void AddItem(SongData songData)
    {
        var cell = Instantiate(songGridPref, parent);
        cell.SetData(songData, descriptionSongPanel);
    }
}
