using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionRes", menuName = "Scriptable Objects/ActionRes")]
public class ActionRes : ScriptableObject
{
    public List<AestheticType> bestTypes;
    public List<AestheticType> averageTypes;
    public List<AestheticType> wrongTypes;
    public float scoreToReach;
}
