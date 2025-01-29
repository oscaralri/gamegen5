using System.Collections.Generic;
using UnityEngine;

public class PlaceableWall : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set;} = Enums.SpotType.Wall;
    
}
