using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bin : MonoBehaviour, IPointerClickHandler
{
    public LayerMask layerMask;
    public bool isErasing = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        isErasing = !isErasing;
        Debug.Log("erasing " + isErasing);
    }
/*
    private void Update()
    {
        if(isErasing)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("raton pulsado y erasing" + isErasing);
                Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = Vector2.zero; 

                RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, layerMask);

                if (hit.collider != null && hit.collider.gameObject.GetComponent<IPlaceableItem>() != null)
                {
                    GameManager.Instance.DecorErased(hit.collider.gameObject.GetComponent<PlaceableItem>());
                    hit.collider.gameObject.GetComponent<PlaceableItem>().SceneFalse();
                    Destroy(hit.collider.gameObject);
                    Debug.Log("borrar");
                }
                else
                {
                    isErasing = false;
                } 
            } 
        }
        
    }
    */
}
