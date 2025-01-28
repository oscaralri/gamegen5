using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bin : MonoBehaviour, IPointerClickHandler
{
    public LayerMask layerMask;
    private bool isErasing = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        // corrutina que se hace hasta que no se le vuelve a dar a la papelera
        isErasing = !isErasing;
        Debug.Log("erasing " + isErasing);
    }

    private void Update()
    {
        if(isErasing)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = Vector2.zero; 

                RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, layerMask);

                if (hit.collider != null && hit.collider.gameObject.GetComponent<IPlaceableItem>() != null)
                {
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    isErasing = false;
                } 
            } 
        }
        
    }
}
