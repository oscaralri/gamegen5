using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptable", menuName = "Scriptable Objects/LevelScriptable")]
public class LevelScriptable : ScriptableObject
{
    public List<ActionRes> toDo1;
    public List<ActionRes> toDo2;
    public List<ActionRes> toDo3;
}
