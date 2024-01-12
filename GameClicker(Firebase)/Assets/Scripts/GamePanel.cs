using DG.Tweening;
using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePanel : Panel
{
    [SerializeField] private SaveUserData saveUserData;
    [SerializeField] private SoundsManager soundsManager;

    private Tween tweenMove;

    private PanelAnimationInteractor animationInteractor;
    private SongInteractor songInteractor;

    public override void Initialize()
    {
        base.Initialize();

        animationInteractor = Game.GetInteractor<PanelAnimationInteractor>();
        songInteractor = Game.GetInteractor<SongInteractor>();
        songInteractor.Play();

        saveUserData.Initialize();
        soundsManager.Initialize();
    }

    public void AddShake()
    {
        if (tweenMove != null) { tweenMove.Kill(); transform.localPosition = Vector3.zero; }
        tweenMove = animationInteractor.Shake(transform, 10, 15, 1, 400);
    }
}
