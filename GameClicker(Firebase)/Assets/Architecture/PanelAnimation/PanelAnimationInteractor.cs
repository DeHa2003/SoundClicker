using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture
{
    public class PanelAnimationInteractor : Interactor
    {
        public void CanvasGroupAlpha(CanvasGroup canvasGroup, float from, float to, float time)
        {
            Coroutines.StartRoutine(SmoothVal(canvasGroup, from, to, time));
        }
        private IEnumerator SmoothVal(CanvasGroup canvasGroup, float from, float to, float timer)
        {
            float t = 0.0f;
            canvasGroup.alpha = from;
            
            while (t < 1.0f)
            {
                t += Time.deltaTime * (1.0f / timer);
                if(canvasGroup != null)
                   canvasGroup.alpha = Mathf.Lerp(from, to, t); //Может быть удалён
                yield return 0;
            }
        }

        public Tween Shake(Transform transform, float duration, float strength = 1, int vibrato = 10, float randomness = 90, bool snappinf = false, bool fadeOut = true, ShakeRandomnessMode shakeRandomness = ShakeRandomnessMode.Full)
        {
            Tween tween = transform.DOShakePosition(duration, strength, vibrato, randomness, snappinf, fadeOut, shakeRandomness);
            return tween;
        }

        public void ChangeColor(Image[] images, TextMeshProUGUI[] texts)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].color = Color.white;
            }

            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].color = Color.white;
            }

            Color randomColor = Random.ColorHSV(0f, 1f, 0f, 1f, 0.6f, 1f, 1f, 1f);

            for (int i = 0; i < images.Length; i++)
            {
                images[i].DOBlendableColor(randomColor, 0.5f);
            }

            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].color = randomColor;
            }
        }
    }
}
