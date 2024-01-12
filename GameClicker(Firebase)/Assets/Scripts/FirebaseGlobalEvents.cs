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
        Debug.Log("Авторизовал аккаунт");
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "Вы вошли в аккаунт с почтой <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email);
    }

    private void OnUserSignOutToAccount()
    {
        Debug.Log("Вышел из аккаунта");
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "Вы вышли из аккаунта");
    }

    private void OnUserRegisterAccount()
    {
        Debug.Log("Зарегистрировал аккаунт");
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "Аккаунт с почтой <color=#53A5FF>" + authenticationInteractor.Auth.CurrentUser.Email + "</color> был зарегистрирован");
    }

    private void OnUserDeleteAccount()
    {
        Debug.Log("Удалил аккаунт");
        audioInteractor.PlayEffectSound("Uvedom");
        notificationInteractor.CreateNotification("Message", "Аккаунт с почтой <color=#53A5FF>" + authenticationInteractor.GetEmail() + "</color> был удалён");
    }

    private void OnErrorSignIn()
    {
        audioInteractor.PlayEffectSound("Error");
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Ошибка авторизации");
    }

    private void OnErrorRegister()
    {
        audioInteractor.PlayEffectSound("Error");
        notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Ошибка регистрации");
    }
}
