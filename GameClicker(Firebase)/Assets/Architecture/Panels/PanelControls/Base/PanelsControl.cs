using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsControl : MonoBehaviour
{
    [SerializeField] protected TransitionPanel transitionPanel;

    protected Panel panel;

    public virtual void Initialize()
    {
        transitionPanel.Initialize();
        CloseTransitionsPanel();
    }

    public void OpenTransitionsPanel(int value)
    {
        transitionPanel.SetSceneNumber(value);
        OpenPanel(transitionPanel);
    }

    public void CloseTransitionsPanel()
    {
        transitionPanel.ClosePanel();
    }

    public void OpenPanel(Panel panel)
    {
        if (this.panel != null)
        {
            this.panel.ClosePanel();
            this.panel = null;
        }

        this.panel = panel;
        this.panel.OpenPanel();
    }
}
