using System.Collections.Generic;
using UnityEngine;

public class PlaceableWall : MonoBehaviour, IPlaceableSpot
{
    public SpotType spotType {get; private set;} = SpotType.Wall;
    
}
