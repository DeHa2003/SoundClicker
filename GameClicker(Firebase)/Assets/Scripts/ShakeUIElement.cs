using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShakeUIElement : MonoBehaviour
{
    public UnityEvent OnShakePanel;

    [Header("Scale effect settings")]
    [SerializeField] private float durationScale;
    [SerializeField] private float strength = 1;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private int randomness = 90;
    [SerializeField] private bool fadeOut = true;
    [SerializeField] private ShakeRandomnessMode randomnessMode;

    public void Shake()
    {
        transform.DOShakeScale(durationScale, strength, vibrato, randomness, fadeOut, randomnessMode);
    }
}
