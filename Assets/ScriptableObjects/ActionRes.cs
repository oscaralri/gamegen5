using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionRes", menuName = "Scriptable Objects/ActionRes")]
public class ActionRes : ScriptableObject
{
    public List<Enums.AestheticType> bestTypes;
    public List<Enums.AestheticType> averageTypes;
    public List<Enums.AestheticType> wrongTypes;
    public float scoreToReach;
    public float currentScore;
    public Enums.ActionType actionID; 
    public bool isActive;
    public AEffectAction effectScriptable;
    public int time;
    public int minutes;
    public bool isOutfit;
    private void OnEnable()
    {
        currentScore = 0f;
        isActive = false;
    }
}
