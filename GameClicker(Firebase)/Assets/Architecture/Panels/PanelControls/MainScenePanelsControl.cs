using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePanelsControl : PanelsControl
{
    [SerializeField] private Panel backgroundPanel;
    [SerializeField] private Panel gamePanel;

    public override void Initialize()
    {
        base.Initialize();

        //PlaneDetection.OnFoundPlanes += OnFoundPlanes;
        //PlaneDetection.OnFoundZeroPosition += OnFoundZeroPos;

        backgroundPanel.Initialize();
        gamePanel.Initialize();
        OpenPanel(gamePanel);
    }

    //private void OnFoundPlanes()
    //{
    //    OpenPanel(choicePlacePanel);
    //    //PlaneDetection.OnFoundPlanes -= OnFoundPlanes;
    //}
    //private void OnFoundZeroPos()
    //{
    //    OpenPanel(choiceARTargetPanel);
    //    //PlaneDetection.OnFoundZeroPosition -= OnFoundZeroPos;
    //}
}
