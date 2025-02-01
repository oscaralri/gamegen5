using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;

public class IconUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject prefab;
    public Enums.DecorType decorType ; // no seguro de si se usará
    private GameObject _draggedObject;
    private String _sortingLayer = "Always On Top";
    public List<Enums.SpotType> validSpots;
    public Enums.AestheticType aestheticType;
    public bool isInScene = false;
    private void Start()
    {

        switch(decorType)
        {
            case Enums.DecorType.Bed:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Wall};
                break;
            case Enums.DecorType.Poster:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Table};
                break;
            default:
                break;

        }
            
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(isInScene == true) return;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z); 

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _draggedObject = Instantiate(prefab, worldPosition, Quaternion.identity);
        _draggedObject.GetComponent<SpriteRenderer>().sortingLayerName = _sortingLayer;
        _draggedObject.transform.SetParent(gameObject.transform);

        _draggedObject.AddComponent<BoxCollider2D>();
        _draggedObject.GetComponent<BoxCollider2D>().isTrigger = true;
        _draggedObject.AddComponent<DraggableCollisions>();

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
        if (_draggedObject != null && _draggedObject.GetComponent<DraggableCollisions>().isPlaceable)
        {
            PlaceFurnitureInScene(eventData);
        }
        Destroy(_draggedObject); 
    }

    private void PlaceFurnitureInScene(PointerEventData eventData)
    {
        //Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        //if (Physics.Raycast(ray, out RaycastHit hit))
        //{//}
        Vector3 mousePosition = Input.mousePosition; // Coordenadas de pantalla

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); // Convertir a coordenadas de mundo
        worldPosition = new Vector3(worldPosition.x, worldPosition.y, 1f);

        GameObject instance = Instantiate(prefab, worldPosition, Quaternion.identity);
        instance.transform.SetParent(gameObject.transform);
        instance.AddComponent<BoxCollider2D>();
        instance.AddComponent<PlaceableItem>();
        instance.GetComponent<PlaceableItem>().aestheticType = aestheticType;

        // cuando se coloca se avisa a gamemanager
        GameManager.Instance.DecorPlaced(instance.GetComponent<PlaceableItem>());
        
    }
}
