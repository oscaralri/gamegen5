using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectScriptableWakeUp", menuName = "Scriptable Objects/EffectScriptableWakeUp")]
public class EffectScriptableWakeUp : AEffectAction
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
        Debug.Log("effectWakeUp");
        UIManager.Instance.ClearText();
        UIManager.Instance.imageSleep.gameObject.SetActive(false);
    }
}
