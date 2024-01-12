using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class ScoreInteractor : Interactor
    {
        public Action OnChangedScore;
        public Action OnChangedMaxScore;
        public int Score { get; private set; }
        public int MaxScore { get; private set; }

        private ScoreRepository scoreRepository;
        public override void Initialize()
        {
            base.Initialize();
            scoreRepository = Game.GetRepository<ScoreRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            MaxScore = scoreRepository.maxscore;
            Score = 0;
        }

        public void SetData(string maxScore)
        {
            this.MaxScore = int.Parse(maxScore);
        }

        public void Save()
        {
            OnChangedMaxScore?.Invoke();
            scoreRepository.maxscore = MaxScore;
            scoreRepository.Save();
        }

        public void AddScore(object sender, int value)
        {
            Score += value;
            OnChangedScore?.Invoke();
            if(Score > MaxScore)
            {
                MaxScore = Score;
                OnChangedMaxScore?.Invoke();
                scoreRepository.maxscore = MaxScore;
                scoreRepository.Save();
            }
        }
    }
}
