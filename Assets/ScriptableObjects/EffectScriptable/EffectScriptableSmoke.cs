using UnityEngine;

[CreateAssetMenu(fileName = "EffectSmokeScriptable", menuName = "Scriptable Objects/EffectSmokeScriptable")]
public class EffectSmokeScriptable : AEffectAction
{
    public override bool isExecuted {get; set;}

    private void OnEnable()
    {
        isExecuted = false;
    }

    public override void Execute()
    {
        Debug.Log("effectSmoke");
    }
}
