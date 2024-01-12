using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionPanel : MovePanel
{
    [SerializeField] private float timeToTransition = 0;

    private int sceneNumber;

    public override void ClosePanel()
    {
        if (tween != null) { tween.Kill(); }

        tween = panel.transform.DOLocalMove(from, time).OnComplete(() => 
        {
            panel.SetActive(false);
        } );
        animationInteractor.CanvasGroupAlpha(canvasGroup, 1, 0, time);
    }
    public override void OpenPanel()
    {
        
        if (tween != null) { tween.Kill(); }
        //PlaySound();
        panel.SetActive(true);
        tween = panel.transform.DOLocalMove(to, time).OnComplete(() => 
        {
            Invoke(nameof(ChangeScene), timeToTransition);
            
        } );
        animationInteractor.CanvasGroupAlpha(canvasGroup, 0, 1, time);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void SetSceneNumber(int value)
    {
        sceneNumber = value;
    }

    protected override void PlaySound()
    {
        //audioInteractor.PlayEffectSound("Whoosh");
    }
}
