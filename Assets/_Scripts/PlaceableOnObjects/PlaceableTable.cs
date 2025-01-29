using UnityEngine;

public class PlaceableTable : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.Table;
}
