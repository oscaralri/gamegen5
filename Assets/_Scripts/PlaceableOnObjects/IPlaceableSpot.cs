using System.Collections.Generic;
using UnityEngine;

public interface IPlaceableSpot
{
    public SpotType spotType {get; }
}

public enum SpotType {Wall, Table}
