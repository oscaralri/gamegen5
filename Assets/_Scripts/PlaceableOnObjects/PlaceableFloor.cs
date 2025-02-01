using UnityEngine;

public class PlaceableFloor : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.Floor;
}
