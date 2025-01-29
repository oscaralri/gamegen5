using UnityEngine;


public abstract class AEffectAction
{
    public abstract Enums.ActionType actionID {get; set; }
    public abstract float timeToCheck {get; set;}
    public abstract void Execute();
}