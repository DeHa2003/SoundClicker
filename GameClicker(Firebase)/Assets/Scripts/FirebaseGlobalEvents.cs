using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class FirebaseGlobalEvents : MonoBehaviour
{
    private FirebaseAuthenticationInteractor authenticationInteractor;
    private NotificationInteractor notificationInteractor;
    public void Initialize()
    {
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();

        authenticationInteractor.OnUserSignInToAccount += OnUserSignInToAccount;
        authenticationInteractor.OnUserSignOutToAccount += OnUserSignOutToAccount;
        authenticationInteractor.OnUserRegisterAccount += OnUserRegisterAccount;
        authenticationInteractor.OnUserDeleteAccount += OnUserDeleteAccount;
        authenticationInteractor.OnErrorSignIn += OnErrorSignIn;
        authenticationInteractor.OnErrorRegister += OnErrorRegister;
    }

    private void OnDestroy()
    {
        authenticationInteractor.OnUserSignInToAccount -= OnUserSignInToAccount;
        authenticationInteractor.OnUserSignOutToAccount -= OnUserSignOutToAccount;
        authenticationInteractor.OnUserRegisterAccount -= OnUserRegisterAccount;
        authenticationInteractor.OnUserDeleteAccount -= OnUserDeleteAccount;
        authenticationInteractor.OnErrorSignIn -= OnErrorSignIn;
        authenticationInteractor.OnErrorRegister -= OnErrorRegister;
    }

    private void OnUserSignInToAccount()
    {
        Debug.Log("����������� �������");
        notificationInteractor.CreateNotification("Message", "�� ����� � ������� � ������ <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email);
    }

    private void OnUserSignOutToAccount()
    {
        Debug.Log("����� �� ��������");
        notificationInteractor.CreateNotification("Message", "�� ����� �� ��������");
    }

    private void OnUserRegisterAccount()
    {
        Debug.Log("��������������� �������");
        notificationInteractor.CreateNotification("Message", "������� � ������ <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email + "</color> ��� ���������������");
    }

    private void OnUserDeleteAccount()
    {
        Debug.Log("������ �������");
        notificationInteractor.CreateNotification("Message", "������� � ������ <color=#53A5FF>" + authenticationInteractor.GetEmail() + "</color> ��� �����");
    }

    private void OnErrorSignIn()
    {
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "������ �����������");
    }

    private void OnErrorRegister()
    {
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "������ �����������");
    }
}
