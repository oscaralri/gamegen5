using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionRes", menuName = "Scriptable Objects/ActionRes")]
public class ActionRes : ScriptableObject
{
    public List<Enums.AestheticType> bestTypes;
    public List<Enums.AestheticType> averageTypes;
    public List<Enums.AestheticType> wrongTypes;
    public float scoreToReach;
    public float currentScore = 0f;
    public Enums.ActionType actionID; 
}
