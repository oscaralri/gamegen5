using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectScriptableWork", menuName = "Scriptable Objects/EffectScriptableWork")]
public class EffectScriptableWork : AEffectAction
{
    public override bool isExecuted {get; set;}
    public List<string> audioClip;
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
        SoundManager.Instance.StopSFX();

        Debug.Log("effectWork");
        UIManager.Instance.ClearText();
        LoadImage();
        foreach(string name in audioClip)
        {
            SoundManager.Instance.PlaySFX(name);
        }
    }
}
