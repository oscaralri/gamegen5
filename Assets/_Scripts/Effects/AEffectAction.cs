using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class AEffectAction : ScriptableObject
{
    //public abstract Enums.ActionType actionID {get; set; }
    public abstract void Execute();
    public abstract bool isExecuted {get; set;}
    public abstract Sprite backgroundToChange {get; set;}
    public abstract List<String> text {get; set;}

    public void LoadImage()
    {
        GameManager.Instance.background.sprite = backgroundToChange;
    }

    public void LoadText()
    {
        UIManager.Instance.LoadText(text);
        UIManager.Instance.ShowText();
    }
}