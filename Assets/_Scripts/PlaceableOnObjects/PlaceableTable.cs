using UnityEngine;

public class PlaceableTable : MonoBehaviour, IPlaceableSpot
{
    public SpotType spotType {get; private set; } = SpotType.Table;
}
