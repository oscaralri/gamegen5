using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceableItem : MonoBehaviour, IPlaceableItem
{
    public Enums.AestheticType aestheticType {get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
       Debug.Log("funciono y" + aestheticType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    private void OnEnable()
    {
        gameObject.GetComponentInParent<IconUI>().isInScene = true;
    }

    private void OnDestroy()
    {
        gameObject.GetComponentInParent<IconUI>().isInScene = false;
    }
}
