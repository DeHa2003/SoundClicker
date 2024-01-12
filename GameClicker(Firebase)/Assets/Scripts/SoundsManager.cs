using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;

    public void Initialize()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Initialize();
        }
    }
}
