using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSongPanel : MovePanel
{
    [SerializeField] private DescriptionSongPanel descriptionSongPanel;
    [SerializeField] private ChooseSong chooseSong;
    public override void Initialize()
    {
        base.Initialize();
        chooseSong.Initialize();
        descriptionSongPanel.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }
}
