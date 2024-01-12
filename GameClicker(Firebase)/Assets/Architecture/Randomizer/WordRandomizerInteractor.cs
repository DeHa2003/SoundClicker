using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Lessons.Architecture
{
    public class WordRandomizerInteractor : Interactor
    {
        public string Word { get; private set; }

        //public Action OnGetSuccess;
        //public Action OnGetFailure;

        public Action OnEndRandomize;

        private const string URL = "https://dinoipsum.com/api/?format=text&paragraphs=1&words=1";
        public void Randomizer()
        {
            Coroutines.StartRoutine(RandomizerCoroutine());
        }

        private  IEnumerator RandomizerCoroutine()
        {
            UnityWebRequest request = UnityWebRequest.Get(URL);

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("No randomizing nickname");
                Word = "ErrorRandom";
                OnEndRandomize?.Invoke();
                yield break;
            }

            Word = request.downloadHandler.text;
            Word = Word.Remove(Word.Length - 3);

            OnEndRandomize?.Invoke();
        }
    }
}
