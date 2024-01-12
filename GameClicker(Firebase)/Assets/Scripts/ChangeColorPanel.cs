using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorPanel : MonoBehaviour
{
    private Image image;
    private Color color;

    private Tween tweenImage;

    private void Start()
    {
        image = GetComponent<Image>();
        color = image.color;
    }

    public void AddShake()
    {
        if (tweenImage != null) { tweenImage.Kill(); }

        image.color = color;
        image.DOBlendableColor(Random.ColorHSV(0f, 1f, 0f, 1f, 0.6f, 1f, 0.1f, 0.1f), 0.5f);
    }
}
