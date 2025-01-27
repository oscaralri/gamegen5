using UnityEngine;

public abstract class ADecorationObject : MonoBehaviour
{
    public string Name {get; private set;}
    protected DecorType DecorType {get; set;}
    public abstract void OnPlaced();

}

public enum DecorType {Bed, Poster, Other}
