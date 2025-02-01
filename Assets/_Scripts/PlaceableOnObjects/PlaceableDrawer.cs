using UnityEngine;

public class PlaceableDrawer : MonoBehaviour, IPlaceableSpot
{
    public Enums.SpotType spotType {get; private set; } = Enums.SpotType.Drawer;
}
