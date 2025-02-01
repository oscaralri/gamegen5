using UnityEngine;

public class PlaceableBed : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.Bed;
}
