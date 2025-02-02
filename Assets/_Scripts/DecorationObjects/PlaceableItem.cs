using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceableItem : MonoBehaviour, IPlaceableItem
{
    public Enums.AestheticType aestheticType {get; set; }
    public GameObject parent;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onpointerclick + " + GameManager.Instance.bin.isErasing);
        if(GameManager.Instance.bin.isErasing == true)
        {
            //SceneFalse();
            Destroy(gameObject);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
/*
    private void OnEnable()
    {
        gameObject.GetComponentInParent<IconUI>().isInScene = true;
    }
*/
    private void OnDestroy()
    {
        gameObject.GetComponentInParent<IconUI>().isInScene = false;
    }

    public void SceneTrue()
    {
        parent.GetComponent<IconUI>().isInScene = true;
    }
/*
    public void SceneFalse()
    {
        parent.GetComponent<IconUI>().isInScene = false;
    }*/
}
