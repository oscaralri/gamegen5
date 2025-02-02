using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectScriptableSleep", menuName = "Scriptable Objects/EffectScriptableSleep")]
public class EffectScriptableSleep : AEffectAction
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
        Debug.Log("effectsleep");
        UIManager.Instance.ClearText();
        LoadImage();
        LoadText();
        Color color = UIManager.Instance.imageSleep.color; 
        color.a = 0.9f; 
        UIManager.Instance.imageSleep.color = color; 
        foreach(string name in audioClip)
        {
            SoundManager.Instance.PlaySFX(name);
        }
    }
}
