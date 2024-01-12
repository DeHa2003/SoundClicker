using Lessons.Architecture;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMainPanel : MovePanel
{
    [SerializeField] private StatusPanel statusPanel;
    [SerializeField] private VizualizeUserData_StartMainPanel vizualizeUserData_StartMainPanel;
    public override void Initialize()
    {
        base.Initialize();
        statusPanel.Initialize();
        vizualizeUserData_StartMainPanel.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        statusPanel.ClosePanel();
    }

    public void Play(int numberScene)
    {
        SceneManager.LoadScene(numberScene);
    }
}
