using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomPanel : MovePanel
{
    public UnityEvent OnStartOpenPanel;
    public UnityEvent OnStartClosePanel;
    public UnityEvent OnCompleteOpenPanel;
    public UnityEvent OnCompleteClosePanel;

    [SerializeField] private Button button;
    public override void OpenPanel()
    {
        OnStartOpenPanel?.Invoke();
        if (tween != null) { tween.Kill(); }
        tween = panel.transform.DOLocalMove(to, time).OnComplete(()=>
        {

            button.onClick.RemoveListener(OpenPanel);
            button.onClick.AddListener(ClosePanel);

            OnCompleteOpenPanel?.Invoke();
        });
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    public override void ClosePanel()
    {
        OnStartClosePanel?.Invoke();
        if (tween != null) { tween.Kill(); }
        tween = panel.transform.DOLocalMove(from, time).OnComplete(() =>
        {
            button.onClick.RemoveListener(ClosePanel);
            button.onClick.AddListener(OpenPanel);

            OnCompleteClosePanel?.Invoke();
        });
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }
}
