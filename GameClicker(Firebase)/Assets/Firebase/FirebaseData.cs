using Firebase.Database;
using Lessons.Architecture;
using System.Collections;
using TMPro;
using UnityEngine;

public class FirebaseData : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameUser;
    [SerializeField] private TextMeshProUGUI coins;

    //private ScoreInteractor scoreInteractor;
    private FirebaseAuthenticationInteractor authInteractor;

    public void Initialize()
    {
        authInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();
    }

    public void GetData()
    {
        StartCoroutine(LoadData());
    }

    public void SaveData()
    {
        User user = new (nameUser.text, int.Parse(coins.text));
        string json = JsonUtility.ToJson(user);
        authInteractor.databaseReference.Child("Users").Child(authInteractor.Auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
    }

    private IEnumerator LoadData()
    {
        var user = authInteractor.databaseReference.Child("Users").Child(authInteractor.Auth.CurrentUser.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => user.IsCompleted);

        if(user.Exception != null)
        {
            Debug.LogWarning(user.Exception);
        }
        else if(user.Result == null)
        {
            Debug.Log("null");
        }
        DataSnapshot data = user.Result;


        nameUser.text = data.Child("Name").Value.ToString();
        coins.text = data.Child("Coins").Value.ToString();
    }
}
