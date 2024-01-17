using DG.Tweening;
using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Sound : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent OnPlaySound;

    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip clip;
    [SerializeField] private float volume;

    private float defaultPitch;

    private ScoreInteractor scoreInteractor;
    public void Initialize()
    {
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();

        m_AudioSource.volume = volume;
    }

    public void SetData(float value)
    {
        defaultPitch = value;
        m_AudioSource.pitch = value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        scoreInteractor.AddScore(this, 1);
        m_AudioSource.pitch = Random.Range(defaultPitch - 0.02f, defaultPitch + 0.02f);
        m_AudioSource.PlayOneShot(clip);
        OnPlaySound?.Invoke();
    }
}
