using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DecorObjectInfo", menuName = "Scriptable Objects/DecorObjectInfo")]
public class DecorObjectInfo : ScriptableObject
{
    public int Name;
    public DecorType DecorType;
    public Sprite icon;
}
