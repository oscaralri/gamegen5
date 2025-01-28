using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptable", menuName = "Scriptable Objects/LevelScriptable")]
public class LevelScriptable : ScriptableObject
{
    public List<AestheticType> bestTypes;
    public List<AestheticType> averageTypes;
    public List<AestheticType> wrongTypes;
}
