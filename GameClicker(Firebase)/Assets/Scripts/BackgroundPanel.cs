using DG.Tweening;
using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanel : Panel
{
    [SerializeField] private TextMeshProUGUI[] texts;
    [SerializeField] private Image[] images;
    [SerializeField] private Score score;

    private Tween tweenMove;

    private PanelAnimationInteractor animationInteractor;

    public override void Initialize()
    {
        base.Initialize();
        animationInteractor = Game.GetInteractor<PanelAnimationInteractor>();
        score.Initialize();
    }

    public void AddShake()
    {
        Move();
        ChangeColor();
    }

    private void Move()
    {
        if (tweenMove != null) { tweenMove.Kill(); transform.localPosition = Vector3.zero; }

        tweenMove = animationInteractor.Shake(transform, 10, 13, 2, 400);

        //tweenMove = transform.DOShakePosition(10, 20, 3, 400, false, false, ShakeRandomnessMode.Full);

        //tweenMove = transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeout, randomnessMode);
    }

    private void ChangeColor()
    {
        //image.color = Color.white;
        //textScore.color = Color.white;
        //randomColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0.6f, 1f, 1f, 1f);
        //image.DOBlendableColor(randomColor, 0.5f);
        //textScore.DOBlendableColor(randomColor, 0.5f);

        animationInteractor.ChangeColor(images, texts);
    }
}
