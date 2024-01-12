using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class FirebaseGlobalEvents : MonoBehaviour
{
    private FirebaseAuthenticationInteractor authenticationInteractor;
    private AudioInteractor audioInteractor;
    private NotificationInteractor notificationInteractor;
    public void Initialize()
    {
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();

        authenticationInteractor.OnUserSignInToAccount += OnUserSignInToAccount;
        authenticationInteractor.OnUserSignOutToAccount += OnUserSignOutToAccount;
        authenticationInteractor.OnUserRegisterAccount += OnUserRegisterAccount;
        authenticationInteractor.OnUserDeleteAccount += OnUserDeleteAccount;
        authenticationInteractor.OnErrorSignIn += OnErrorSignIn;
        authenticationInteractor.OnErrorRegister += OnErrorRegister;
    }

    private void OnDisable()
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
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "�� ����� � ������� � ������ <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email);
    }

    private void OnUserSignOutToAccount()
    {
        Debug.Log("����� �� ��������");
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "�� ����� �� ��������");
    }

    private void OnUserRegisterAccount()
    {
        Debug.Log("��������������� �������");
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "������� � ������ <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email + "</color> ��� ���������������");
    }

    private void OnUserDeleteAccount()
    {
        Debug.Log("������ �������");
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "������� � ������ <color=#53A5FF>" + authenticationInteractor.GetEmail() + "</color> ��� �����");
    }

    private void OnErrorSignIn()
    {
        audioInteractor.PlayEffectSound("Error");
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "������ �����������");
    }

    private void OnErrorRegister()
    {
        audioInteractor.PlayEffectSound("Error");
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "������ �����������");
    }
}
