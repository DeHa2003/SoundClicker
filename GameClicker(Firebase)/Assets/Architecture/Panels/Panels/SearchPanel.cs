using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPanel : Panel
{
    [SerializeField] private Ease ease;
    [SerializeField] private Vector3 vectorToRotatePhone;
    [SerializeField] private float timeToRotate;
    [SerializeField] private Transform phone;

    private Tween tween;
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        tween = phone.DORotate(vectorToRotatePhone, timeToRotate).SetEase(ease).SetLoops(-1, LoopType.Yoyo);
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        tween.Kill();

    }
}
