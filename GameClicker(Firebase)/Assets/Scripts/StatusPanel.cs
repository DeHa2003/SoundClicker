using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusPanel : Panel
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float timeAlpha;
    [SerializeField] private VisualizeUserData_StatusPanel visual;
    [SerializeField] private ButtonEvents buttonEvents;

    private PanelAnimationInteractor animationInteractor;

    public override void Initialize()
    {
        base.Initialize();
        animationInteractor = Game.GetInteractor<PanelAnimationInteractor>();

        visual.Initialize();
        buttonEvents.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, timeAlpha);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, timeAlpha);
        visual.GetNickname();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
    }
}
