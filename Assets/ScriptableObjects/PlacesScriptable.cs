using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlacesScriptable", menuName = "Scriptable Objects/PlacesScriptable")]
public class PlacesScriptable : ScriptableObject
{
    public Sprite background;
    public List<IPlaceableItem> placeableItems; 
}
