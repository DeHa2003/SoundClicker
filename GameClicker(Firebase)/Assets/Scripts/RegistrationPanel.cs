using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrationPanel : MovePanel
{
    [SerializeField] private FirebaseAuthentication firebaseAuthentication;
    public override void Initialize()
    {
        base.Initialize();
        firebaseAuthentication.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }
}
