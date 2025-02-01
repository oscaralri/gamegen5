using UnityEngine;


public abstract class AEffectAction : ScriptableObject
{
    //public abstract Enums.ActionType actionID {get; set; }
    public abstract void Execute();
    public abstract bool isExecuted {get; set;}
}