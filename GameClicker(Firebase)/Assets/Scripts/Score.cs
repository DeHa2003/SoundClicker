using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textMaxScore;

    private ScoreInteractor scoreInteractor;
    public void Initialize()
    {
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();

        scoreInteractor.OnChangedScore += GetScore;
        scoreInteractor.OnChangedMaxScore += GetMaxScore;

        GetScore();
        GetMaxScore();
    }

    private void GetScore()
    {
        textScore.text = scoreInteractor.Score.ToString();
    }

    private void GetMaxScore()
    {
        textMaxScore.text = scoreInteractor.MaxScore.ToString();
    }
}
