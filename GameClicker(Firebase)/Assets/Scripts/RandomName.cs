using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RandomName : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI randomNickText;

    //private WordRandomizerInteractor randomizerInteractor;

    private void Awake()
    {
        //randomizerInteractor = Game.GetInteractor<WordRandomizerInteractor>();

        //randomizerInteractor.OnGetSuccess += () => 
        //{ 
        //    randomNickText.text = randomizerInteractor.Word;
        //    buttonRandom.gameObject.SetActive(true);
        //};

        //randomizerInteractor.OnGetFailure += () =>
        //{
        //    buttonRandom.gameObject.SetActive(true);
        //};

    }

    //private void GetRandomWord()
    //{
    //    buttonRandom.gameObject.SetActive(false);
    //    randomizerInteractor.Randomizer();
    //}
}
