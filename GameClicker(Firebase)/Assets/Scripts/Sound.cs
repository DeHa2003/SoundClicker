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

    private float defaultVolume;
    private float defaultPitch;

    private ScoreInteractor scoreInteractor;
    public void Initialize()
    {
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();
    }

    public void SetData(float pitchValue, float volumeValue)
    {
        defaultPitch = pitchValue;
        defaultVolume = volumeValue;

        m_AudioSource.pitch = pitchValue;
        m_AudioSource.volume = volumeValue;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_AudioSource.pitch = Random.Range(defaultPitch - 0.02f, defaultPitch + 0.02f);
        m_AudioSource.volume = Random.Range(defaultVolume - 0.01f, defaultVolume + 0.01f);
        m_AudioSource.PlayOneShot(clip);

        scoreInteractor.AddScore(this, 1);
        OnPlaySound?.Invoke();
    }
}
