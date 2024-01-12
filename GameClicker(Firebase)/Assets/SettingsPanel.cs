using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MovePanel
{
    [SerializeField]
    private Settings settings;
    public override void Initialize()
    {
        base.Initialize();
        settings.Initialize();
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
