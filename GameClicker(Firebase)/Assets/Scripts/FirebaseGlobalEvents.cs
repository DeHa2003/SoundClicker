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
        Debug.Log("Авторизовал аккаунт");
        notificationInteractor.CreateNotification("Message", "Вы вошли в аккаунт с почтой <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email);
    }

    private void OnUserSignOutToAccount()
    {
        Debug.Log("Вышел из аккаунта");
        notificationInteractor.CreateNotification("Message", "Вы вышли из аккаунта");
    }

    private void OnUserRegisterAccount()
    {
        Debug.Log("Зарегистрировал аккаунт");
        notificationInteractor.CreateNotification("Message", "Аккаунт с почтой <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email + "</color> был зарегистрирован");
    }

    private void OnUserDeleteAccount()
    {
        Debug.Log("Удалил аккаунт");
        notificationInteractor.CreateNotification("Message", "Аккаунт с почтой <color=#53A5FF>" + authenticationInteractor.GetEmail() + "</color> был удалён");
    }

    private void OnErrorSignIn()
    {
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Ошибка авторизации");
    }

    private void OnErrorRegister()
    {
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Ошибка регистрации");
    }
}
