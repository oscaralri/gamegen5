using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab;
    public DecorType decorType; // no seguro de si se usará
    private GameObject _draggedObject;
    private String _sortingLayer = "Always On Top";

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); 

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _draggedObject = Instantiate(prefab, worldPosition, Quaternion.identity);
        _draggedObject.GetComponent<SpriteRenderer>().sortingLayerName = _sortingLayer;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_draggedObject != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); 

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            _draggedObject.transform.position = worldPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_draggedObject != null)
        {
            PlaceFurnitureInScene(eventData);
            Destroy(_draggedObject); 
        }
    }

    private void PlaceFurnitureInScene(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(prefab, hit.point, Quaternion.identity);
        }
    }
}
