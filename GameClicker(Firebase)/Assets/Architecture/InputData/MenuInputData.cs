using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputData : MonoBehaviour
{
    [Header("Notification")]
    [SerializeField] protected NotificationControl notificationControl;
    [SerializeField] protected Notification notification;

    [Header("Audio")]
    [SerializeField] protected AudioManager audioManager;

    private NotificationInteractor notificationInteractor;
    private AudioInteractor audioInteractor;
    private GeneralSettingsInteractor settingsInteractor;

    public void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        settingsInteractor = Game.GetInteractor<GeneralSettingsInteractor>();

        audioInteractor.SetData(audioManager, "Menu");
        notificationInteractor.SetData(notification, notificationControl);
        settingsInteractor.SetData(audioManager);
    }
}
