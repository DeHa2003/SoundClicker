using Firebase.Database;
using Google.MiniJSON;
using Lessons.Architecture;
using System;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData instance;

    private readonly Regex regex = new("^[a-zA-Zа-яА-Я0-9]*$");

    Action OnSuccesGetName = null;

    private WordRandomizerInteractor randomizerInteractor;
    private UserInteractor userInteractor;
    private ScoreInteractor scoreInteractor;
    private FirebaseAuthenticationInteractor authenticationInteractor;
    private NotificationInteractor notificationInteractor;
    private AudioInteractor audioInteractor;
    public void Initialize()
    {
        instance = this;

        audioInteractor = Game.GetInteractor<AudioInteractor>();
        randomizerInteractor = Game.GetInteractor<WordRandomizerInteractor>();
        userInteractor = Game.GetInteractor<UserInteractor>();
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();

        authenticationInteractor.OnUserRegisterAccount += CreateEmptyDataToServer;
        authenticationInteractor.OnUserSignInToAccount += LoadServerDataToLocal;
        authenticationInteractor.OnUserSignOutToAccount += DeleteLocalData;
        authenticationInteractor.OnUserDeleteAccount += DeleteServerData;

        CreateFirstNickname();
        LoadServerDataToLocal();
    }

    private void OnDestroy()
    {
        authenticationInteractor.OnUserRegisterAccount -= CreateEmptyDataToServer;
        authenticationInteractor.OnUserSignInToAccount -= LoadServerDataToLocal;
        authenticationInteractor.OnUserSignOutToAccount -= DeleteLocalData;
        authenticationInteractor.OnUserDeleteAccount -= DeleteServerData;
    }

    private void CreateEmptyDataToServer()
    {
        OnSuccesGetName = () =>
        {
            randomizerInteractor.OnEndRandomize -= OnSuccesGetName;

            string name = randomizerInteractor.Word;
            int coins = 0;

            User user = new(name, coins);
            string json = JsonUtility.ToJson(user);

            authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
            LoadServerDataToLocal();
        };

        randomizerInteractor.OnEndRandomize += OnSuccesGetName;
        randomizerInteractor.Randomizer();

    }//Создание пустой бд

    private void LoadServerDataToLocal()
    {
        if(authenticationInteractor.CheckUserAuthentication() == true)
        {
            StartCoroutine(LoadServerDataToLocal_Coroutine());
        }
    }//Запись серверных данных в локальные

    private void LoadLocalDataToServer()
    {
        if (authenticationInteractor.CheckUserAuthentication() == true)
        {
            User user = new(userInteractor.NameUser, scoreInteractor.MaxScore);
            string json = JsonUtility.ToJson(user);
            authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
        }
    }//Запись локальных данных в сервер

    private void DeleteServerData()//Удаление серверных данных
    {
        DeleteLocalData();

        if (authenticationInteractor.CheckUserAuthentication() == true)
        {
            var user = authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId);
            user.RemoveValueAsync();
        }
    }

    private void DeleteLocalData()//Удаление локальных данных
    {
        scoreInteractor.SetData("0");
        scoreInteractor.Save();
    }

    public void ChangeNickname(string newNickname)
    {
        if(userInteractor.NameUser == newNickname)
        {
            notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Вы не изменили ник");
            audioInteractor.PlayNotificationSound("Error");
            return;
        }

        if (!regex.IsMatch(newNickname))
        {
            notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Можно использовать только цифры, английские и русские буквы");
            audioInteractor.PlayNotificationSound("Error");
            return;
        }

        if (newNickname.Length < 3 || newNickname.Length > 15)
        {
            notificationInteractor.CreateNotification("<color=#ff0000>Error</color>", "Количество символов не меньше 3 и не больше 15");
            audioInteractor.PlayNotificationSound("Error");
            return;
        }

        if (authenticationInteractor.CheckUserAuthentication() == true)
        {
            authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId).Child("Name").SetValueAsync(newNickname);
        }

        audioInteractor.PlayNotificationSound("Success");
        notificationInteractor.CreateNotification("Message", "Новый никнейм - <color=#53A5FF>" + newNickname);

        userInteractor.SetData(newNickname);
        userInteractor.Save();
    }

    private void CreateFirstNickname()
    {
        if(authenticationInteractor.CheckUserAuthentication() == false)
        {
            if (userInteractor.NameUser == null || userInteractor.NameUser == "")
            {
                OnSuccesGetName = () =>
                {
                    string name = randomizerInteractor.Word;

                    userInteractor.SetData(name);
                    userInteractor.Save();
                    randomizerInteractor.OnEndRandomize -= OnSuccesGetName;
                };

                randomizerInteractor.OnEndRandomize += OnSuccesGetName;
                randomizerInteractor.Randomizer();

                return;
            }
        }
    }//Создание первого никнейма

    private IEnumerator LoadServerDataToLocal_Coroutine()
    {
        var user = authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if (user.Exception != null)
        {
            Debug.LogWarning(user.Exception);
        }
        else if (user.Result == null)
        {
            Debug.Log("null");
        }
        DataSnapshot data = user.Result;

        string name = data.Child("Name").Value.ToString();
        string coins = data.Child("Coins").Value.ToString();

        //if (name == null)
        //{
        //    name = "Default";
        //    authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId).Child("Name").SetValueAsync(name);
        //}

        //if(coins == null)
        //{
        //    coins = 0.ToString();
        //    authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId).Child("Coins").SetValueAsync(coins);
        //}

        userInteractor.SetData(name);
        userInteractor.Save();

        scoreInteractor.SetData(coins);
        scoreInteractor.Save();
    }
}

public class User
{
    public string Name;
    public int Coins;

    public User(string name, int coins)
    {
        this.Name = name;
        this.Coins = coins;
    }
}
