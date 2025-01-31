using UnityEngine.EventSystems;

public interface IPlaceableItem : IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // define interacción de rollo coger, mover, solta blabla
    public Enums.AestheticType aestheticType {get; }

    
}
