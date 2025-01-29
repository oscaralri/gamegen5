using UnityEngine;

public class EffectExample : AEffectAction
{
    
    public override Enums.ActionType actionID { get; set; } = Enums.ActionType.Smoke;
    public override float timeToCheck { get; set; } = 12f;

    public override void Execute()
    {
        Debug.Log("EffectExample execute");
    }
}
