using UnityEngine;

public abstract class ADecorationObject : MonoBehaviour
{
    public string Name {get; private set;}
    protected Enums.DecorType DecorType {get; set;}
    public abstract void OnPlaced();

}


