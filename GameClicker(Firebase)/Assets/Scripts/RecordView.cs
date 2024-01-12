using Firebase.Database;
using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecordView : MonoBehaviour
{
    [SerializeField] private GameObject notAvtorizatePanel;
    [SerializeField] private UserGrid userGrid;
    [SerializeField] private Transform content;

    private Dictionary<string, int> recordsTable = new Dictionary<string, int>();

    private FirebaseAuthenticationInteractor firebaseAuthentication;
    public void Initialize()
    {
        firebaseAuthentication = Game.GetInteractor<FirebaseAuthenticationInteractor>();
    }

    public void DisplayPlayerRecord()
    {
        if(firebaseAuthentication.CheckUserAuthentication() == false)
        {
            notAvtorizatePanel.SetActive(true);
            return;
        }

        StartCoroutine(DisplayPlayerRecord_Coroutine());
    }

    private IEnumerator DisplayPlayerRecord_Coroutine()
    {
        var task = firebaseAuthentication.databaseReference.Child("Users").OrderByChild("Coins").LimitToFirst(15).GetValueAsync();

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            Debug.Log("Error display record");
            yield break;
        }

        DataSnapshot data = task.Result;

        Debug.Log("Success " + data.ChildrenCount);


        foreach (var user in data.Children)
        {
            //string name = user.Child("Name").Value.ToString();
            //string coins = user.Child("Coins").Value.ToString();
            recordsTable.Add(user.Child("Name").Value.ToString(), int.Parse(user.Child("Coins").Value.ToString()));
        }

        recordsTable = recordsTable.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


        foreach (var item in recordsTable)
        {
            UserGrid grid = Instantiate(userGrid, content);
            grid.SetData(item.Key, item.Value.ToString());
        }
    }

    public void DeletePlayerRecords()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
        }

        recordsTable.Clear();

        if (notAvtorizatePanel.activeSelf)
            notAvtorizatePanel.SetActive(false);
    }
}
