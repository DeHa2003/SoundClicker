using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordsPanel : MovePanel
{
    [SerializeField] private RecordView recordView;

    private NotificationInteractor notificationInteractor;
    public override void Initialize()
    {
        base.Initialize();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        recordView.Initialize();
    }

    public override void OpenPanel()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Нет подключения к интернету");
        }
        base.OpenPanel();
        recordView.DisplayPlayerRecord();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        recordView.DeletePlayerRecords();
    }
}
