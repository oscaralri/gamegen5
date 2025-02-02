using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "EffectSmokeScriptable", menuName = "Scriptable Objects/EffectSmokeScriptable")]
public class EffectSmokeScriptable : AEffectAction
{
    public override bool isExecuted {get; set;}
    
    public Sprite _backgroundToChange;
    public List<String> _text;

    public override Sprite backgroundToChange
    {
        get => _backgroundToChange;
        set => _backgroundToChange = value;
    }

    public override List<String> text
    {
        get => _text;
        set => _text = value;
    }

    private void OnEnable()
    {
        isExecuted = false;
    }

    public override void Execute()
    {
        Debug.Log("effectSmoke");
        LoadImage();
        LoadText();
    }
}
