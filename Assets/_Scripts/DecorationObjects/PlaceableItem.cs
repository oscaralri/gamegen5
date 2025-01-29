using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceableItem : MonoBehaviour, IPlaceableItem
{
    public Enums.AestheticType aestheticType {get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
