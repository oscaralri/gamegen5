using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DecorObjectInfo", menuName = "Scriptable Objects/DecorObjectInfo")]
public class DecorObjectInfo : ScriptableObject
{
    public string Name;
    public Enums.DecorType DecorType;
    public Sprite Icon;
    public GameObject Prefab;
    public Enums.AestheticType aestheticType; 
}

