using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualDataPanel : Panel
{
    [SerializeField] private VisualizeUserData_StatusPanel visualUserData;
    public override void Initialize()
    {
        base.Initialize();
        visualUserData.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        //visualUserData.GetData();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }
}
