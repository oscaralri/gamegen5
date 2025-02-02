using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectScriptableWakeUp", menuName = "Scriptable Objects/EffectScriptableWakeUp")]
public class EffectScriptableWakeUp : AEffectAction
{
    [SerializeField] private bool _isExecuted = false;
    public override bool isExecuted 
    {
        get => _isExecuted;
        set => _isExecuted = value;
    }

    public List<string> audioClip;
    public Sprite _backgroundToChange;
    public List<string> _text;

    public override Sprite backgroundToChange
    {
        get => _backgroundToChange;
        set => _backgroundToChange = value;
    }

    public override List<string> text
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

        Debug.Log("effectWakeUp");

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ClearText();
            Color color = UIManager.Instance.imageSleep.color;
            color.a = 0f; 
            UIManager.Instance.imageSleep.color = color;
        }

        foreach(string name in audioClip)
        {
            SoundManager.Instance.PlaySFX(name);
        }
    }
}
