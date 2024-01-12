using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VizualizeUserData_StartMainPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textStatus;

    private FirebaseAuthenticationInteractor authenticationInteractor;

    public void Initialize()
    {
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();
        authenticationInteractor.OnChangeUser += GetEmail;
        GetEmail();

    }

    private void GetEmail()
    {
        textStatus.text = authenticationInteractor.GetEmail();
    }
}
