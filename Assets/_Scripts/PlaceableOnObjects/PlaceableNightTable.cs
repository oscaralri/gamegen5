using UnityEngine;

public class PlaceableNightTable : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.NightTable;
}
