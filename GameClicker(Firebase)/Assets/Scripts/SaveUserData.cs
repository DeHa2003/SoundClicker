using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SaveUserData : MonoBehaviour
{
    private FirebaseAuthenticationInteractor authenticationInteractor;
    private ScoreInteractor scoreInteractor;
    private UserInteractor userInteractor;

    public void Initialize()
    {
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();
        userInteractor = Game.GetInteractor<UserInteractor>();
    }
    public void SaveServerData()
    {
        if(authenticationInteractor.CheckUserAuthentication() == true)
        {
            User user = new(userInteractor.NameUser, scoreInteractor.MaxScore);
            string json = JsonUtility.ToJson(user);
            authenticationInteractor.databaseReference.Child("Users").Child(authenticationInteractor.Auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
        }
    }

    private void OnDestroy()
    {
        SaveServerData();
    }
}
