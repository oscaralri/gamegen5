
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActionsInTime", menuName = "Scriptable Objects/ActionsInTime")]
public class ActionsInTime : ScriptableObject
{
    public List<ActionTimeEntry> actionEntries;
}