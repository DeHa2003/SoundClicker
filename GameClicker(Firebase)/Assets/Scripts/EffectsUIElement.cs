using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EffectsUIElement : MonoBehaviour
{
    [Header("Scale effect settings")]
    [SerializeField] private float durationScale;
    [SerializeField] private float strength = 1;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private int randomness = 90;
    [SerializeField] private bool fadeOut = true;
    [SerializeField] private ShakeRandomnessMode randomnessMode;

    [Header("Image setting effect")]
    [SerializeField] private Color clickColor;
    [SerializeField] private float durationColor;
    private Color defaultColor;
    private Vector3 defaultScale;

    private Image image;

    private Tween tweenScale;
    private Tween tweenImage;

    private void Start()
    {
        image = GetComponent<Image>();
        defaultScale = transform.localScale;
        defaultColor = image.color;
    }

    public void Play()
    {
        ChangeColor();
        Shake();
    }

    private void ChangeColor()
    {
        if (tweenImage != null) { tweenImage.Kill(); }
        image.color = clickColor;
        tweenImage = image.DOColor(defaultColor, durationColor);
    }

    private void Shake()
    {
        if(tweenScale != null) { tweenScale.Kill(); transform.localScale = defaultScale; }
        tweenScale = transform.DOShakeScale(durationScale, strength, vibrato, randomness, fadeOut, randomnessMode);
    }
}
