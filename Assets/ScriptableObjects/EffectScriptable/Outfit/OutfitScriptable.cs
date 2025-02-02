using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OutfitScriptable", menuName = "Scriptable Objects/OutfitScriptable")]
public class OutfitScriptable : AEffectAction
{
    public override bool isExecuted {get; set;}
    
    public Sprite _backgroundToChange;
    public List<String> _text;
    public Sprite outfit;

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
        Debug.Log("effectOutfit");
        UIManager.Instance.ClearText();
        UIManager.Instance.ChangeOutfit(outfit);
        
    }
}
