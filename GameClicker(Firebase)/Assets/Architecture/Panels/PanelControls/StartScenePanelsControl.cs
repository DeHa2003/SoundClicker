using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScenePanelsControl : PanelsControl
{
    [SerializeField] private Panel startBackgroundPanel;
    [SerializeField] private Panel startMainPanel;
    [SerializeField] private Panel recordsPanel;
    [SerializeField] private Panel chooseSongPanel;
    [SerializeField] private Panel registrationPanel;
    [SerializeField] private Panel avtorizationPanel;
    [SerializeField] private Panel settingsPanel;

    public override void Initialize()
    {
        base.Initialize();

        avtorizationPanel.Initialize();
        registrationPanel.Initialize();
        startBackgroundPanel.Initialize();
        startMainPanel.Initialize();
        recordsPanel.Initialize();
        chooseSongPanel.Initialize();
        settingsPanel.Initialize();

        OpenPanel(startMainPanel);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
