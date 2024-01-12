using Lessons.Architecture;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class VisualizeUserData_StatusPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI emailText;
    [SerializeField] private TMP_InputField nicknameText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private ScoreInteractor scoreInteractor;
    private UserInteractor userInteractor;
    private FirebaseAuthenticationInteractor authenticationInteractor;

    public void Initialize()
    {
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();
        userInteractor = Game.GetInteractor<UserInteractor>();
        authenticationInteractor = Game.GetInteractor<FirebaseAuthenticationInteractor>();

        scoreInteractor.OnChangedMaxScore += GetScore;
        userInteractor.OnChangeName += GetNickname;
        authenticationInteractor.OnChangeUser += GetEmail;

        GetNickname();
        GetScore();
        GetEmail();
    }

    public void GetNickname()
    {
        nicknameText.text = userInteractor.NameUser;
    }

    private void GetScore()
    {
        scoreText.text = scoreInteractor.MaxScore.ToString();
    }

    private void GetEmail()
    {
        emailText.text = authenticationInteractor.GetEmail();
    }
}
