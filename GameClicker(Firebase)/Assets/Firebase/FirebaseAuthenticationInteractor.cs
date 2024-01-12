using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Lessons.Architecture
{
    public class FirebaseAuthenticationInteractor : Interactor
    {
        public event Action OnChangeUser;

        public event Action OnUserSignInToAccount;
        public event Action OnUserSignOutToAccount;

        public event Action OnUserRegisterAccount;
        public event Action OnUserDeleteAccount;

        public event Action OnErrorSignIn;
        public event Action OnErrorRegister;

        public DatabaseReference databaseReference;

        public FirebaseAuth Auth { get; private set; }
        public override void Initialize()
        {
            base.Initialize();

            Auth = FirebaseAuth.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        }
        

        public void SignIn(string emailTextValue, string passwordTextValue)
        {
            Coroutines.StartRoutine(SignInCoroutine(emailTextValue, passwordTextValue));
        }

        private IEnumerator SignInCoroutine(string emailTextValue, string passwordTextValue)
        {
            Task<AuthResult> task = Auth.SignInWithEmailAndPasswordAsync(emailTextValue, passwordTextValue);

            yield return new WaitUntil(() => task.IsCompleted);

            if (task.Exception != null)
            {
                OnErrorSignIn?.Invoke();
                yield break;
            }

            OnChangeUser?.Invoke();
            OnUserSignInToAccount?.Invoke();
        }

        public void SignUp(string emailTextValue, string passwordTextValue)
        {
            Coroutines.StartRoutine(SignUpCoroutine(emailTextValue, passwordTextValue));
        }

        private IEnumerator SignUpCoroutine(string emailTextValue, string passwordTextValue)
        {
            var task = Auth.CreateUserWithEmailAndPasswordAsync(emailTextValue, passwordTextValue);

            yield return new WaitUntil(predicate: () => task.IsCompleted);

            if (task.Exception != null)
            {
                OnErrorRegister?.Invoke();
                yield break;
            }

            OnChangeUser?.Invoke();
            OnUserRegisterAccount?.Invoke();
            
        }

        public void SignOut()
        {
            OnUserSignOutToAccount?.Invoke();
            Auth.SignOut();
            OnChangeUser?.Invoke();
        }

        public void DeleteAuth()
        {
            OnUserDeleteAccount?.Invoke();
            Coroutines.StartRoutine(DeleteAuth_Coroutine());
        }

        private IEnumerator DeleteAuth_Coroutine()
        {
            var task = Auth.CurrentUser.DeleteAsync();

            yield return new WaitUntil(predicate: () => task.IsCompleted);

            if (task.Exception != null)
            {
                Debug.Log("Ошибка удаления аккаунта");
                yield break;
            }

            SignOut();
        }

        public string GetEmail()
        {
            if (CheckUserAuthentication() == true)
            {
                return Auth.CurrentUser.Email;
            }
            else
            {
                return "Не авторизован";
            }
        }

        public bool CheckUserAuthentication()
        {
            if (Auth.CurrentUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
