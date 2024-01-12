using DG.Tweening;
using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartBackgroundPanel : Panel, IPointerDownHandler
{
    public float duration;
    public float strength = 1;
    public int vibrato = 10;
    public float randomness = 90;
    public bool snapping;
    public bool fadeout;
    public ShakeRandomnessMode randomnessMode;

    private Tween tweenMove;

    public override void Initialize()
    {
        base.Initialize();
        AddShake();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public void AddShake()
    {
        if (tweenMove != null) { tweenMove.Kill(); transform.localPosition = Vector3.zero; }

        tweenMove = transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeout, randomnessMode);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AddShake();
    }
}
