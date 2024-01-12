using Firebase.Auth;
using Google.MiniJSON;
using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirebaseAuthentication : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    private NotificationInteractor notificationInteractor;
    private FirebaseAuthenticationInteractor authenticationInteractor;

    public void Initialize()
    {
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();
    }

    public void SignIn() //Авторизация
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Нет подключения к интернету");
            return;
        }

        authenticationInteractor.SignIn(emailInputField.text, passwordInputField.text);
    }

    public void SignUp() //Регистрация
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Нет подключения к интернету");
            return;
        }

        authenticationInteractor.SignUp(emailInputField.text, passwordInputField.text);
    }

    public void SignOut() //Выход из аккаунта
    {
        authenticationInteractor.SignOut(); 
    }

    public void DeleteAuth() //Удаление аккаунта
    {
        authenticationInteractor.DeleteAuth();
    }
}
