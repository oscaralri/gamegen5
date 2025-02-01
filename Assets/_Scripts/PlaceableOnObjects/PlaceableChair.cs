using UnityEngine;

public class PlaceableChair : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.Chair;
}
