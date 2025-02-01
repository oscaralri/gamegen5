using UnityEngine;

public class PlaceableCarpet : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.Carpet;
}
