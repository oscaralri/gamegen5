using UnityEngine;

public class PlaceableShelve : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.Shelves;
}
