using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    [SerializeField] private protected GameObject panel;

    //protected AudioInteractor audioInteractor;
    public virtual void Initialize() 
    { 
        //audioInteractor = Game.GetInteractor<AudioInteractor>(); 
    }
    public virtual void OpenPanel() 
    { 
        panel.SetActive(true); 
        //audioInteractor.PlayEffectSound("OpenMain"); 
    }
    public virtual void ClosePanel() 
    { 
        panel.SetActive(false); 
    }
}
