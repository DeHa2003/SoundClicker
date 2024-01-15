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
    [SerializeField] private float pitch;

    private ScoreInteractor scoreInteractor;
    public void Initialize()
    {
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();

        m_AudioSource.pitch = pitch;
        m_AudioSource.volume = volume;
    }

    public void SetData(float value)
    {
        m_AudioSource.pitch = value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        scoreInteractor.AddScore(this, 1);
        m_AudioSource.pitch = Random.Range(pitch - 0.02f, pitch + 0.02f);
        m_AudioSource.PlayOneShot(clip);
        OnPlaySound?.Invoke();
    }
}
