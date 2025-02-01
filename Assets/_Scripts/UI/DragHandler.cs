using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab; 
    private GameObject draggedObject;
    private Canvas canvas; 
    public GameObject parent;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>(); 
        parent = GameObject.Find("PlacedObjects");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggedObject = Instantiate(gameObject, canvas.transform);
        //draggedObject.transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedObject != null)
        {
            RectTransform rect = draggedObject.GetComponent<RectTransform>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 position
            );
            rect.anchoredPosition = position; 
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedObject != null)
        {
            CreateFurnitureInScene(eventData);
            Destroy(draggedObject); 
        }
    }

    private void CreateFurnitureInScene(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject newFurniture = Instantiate(prefab, hit.point, Quaternion.identity);
            newFurniture.transform.SetParent(parent.transform, true); 
        }
    }
}
