using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PagesScriptable", menuName = "Scriptable Objects/PagesScriptable")]
public class PagesScriptable : ScriptableObject
{
    public List<ScriptableObject> scriptableObjects;
}
