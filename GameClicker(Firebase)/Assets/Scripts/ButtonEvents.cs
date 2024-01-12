using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject SignInButtons;
    [SerializeField] private GameObject SignOutButtons;

    private FirebaseAuthenticationInteractor authenticationInteractor;
    public void Initialize()
    {
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();

        authenticationInteractor.OnUserSignInToAccount += ActivateSignInButtons;
        authenticationInteractor.OnUserRegisterAccount += ActivateSignInButtons;

        authenticationInteractor.OnUserDeleteAccount += ActivateSignOutButtons;
        authenticationInteractor.OnUserSignOutToAccount += ActivateSignOutButtons;

        if(authenticationInteractor.CheckUserAuthentication() == true)
        {
            ActivateSignInButtons();
        }
        else
        {
            ActivateSignOutButtons();
        }
    }

    public void SignOut()
    {
        authenticationInteractor.SignOut();
    }

    public void DeleteAccount()
    {
        authenticationInteractor.DeleteAuth();
    }

    private void ActivateSignInButtons()
    {
        SignInButtons.SetActive(true);
        SignOutButtons.SetActive(false);
    }

    private void ActivateSignOutButtons()
    {
        SignInButtons.SetActive(false);
        SignOutButtons.SetActive(true);
    }
}
