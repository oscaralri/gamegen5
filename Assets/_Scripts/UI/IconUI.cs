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
    private bool _isColor = false;
    private GameObject _furniture;
    private void Start()
    {

        switch(decorType)
        {
            case Enums.DecorType.Poster:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Table};
                break;

            // colors 
            case Enums.DecorType.ColorBed:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Bed};
                _furniture = GameManager.Instance.furniture[0];
                _isColor = true;
                break;
            case Enums.DecorType.ColorChair:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Chair};
                _furniture = GameManager.Instance.furniture[1];
                _isColor = true;
                break;
            case Enums.DecorType.ColorDrawer:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Drawer};
                _furniture = GameManager.Instance.furniture[2];
                _isColor = true;
                break;
            case Enums.DecorType.ColorNightTable:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.NightTable};
                _furniture = GameManager.Instance.furniture[3];
                _isColor = true;
                break;
            case Enums.DecorType.ColorShelves:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Shelves};
                _furniture = GameManager.Instance.furniture[4];
                _isColor = true;
                break;
            case Enums.DecorType.ColorTable:
                validSpots = new List<Enums.SpotType>{Enums.SpotType.Table};
                _furniture = GameManager.Instance.furniture[5];
                _isColor = true;
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
        if(_draggedObject != null && _draggedObject.GetComponent<DraggableCollisions>().isPlaceable && _isColor == true)
        {
            Debug.Log("concha entro");
            switch(validSpots[0])
            {
                case Enums.SpotType.Wall:
                    if(GameManager.Instance.furniture[0].GetComponent<SpriteRenderer>().sprite == null) Debug.Log("va");
                    GameManager.Instance.furniture[0].GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
                    break;
                case Enums.SpotType.Table:
                    GameManager.Instance.furniture[1].GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
                    if(GameManager.Instance.furniture[1].GetComponent<SpriteRenderer>().sprite == null) Debug.Log("va");
                    break;


                default:
                    break;
            }

         
        }
        else if (_draggedObject != null && _draggedObject.GetComponent<DraggableCollisions>().isPlaceable)
        {
            PlaceFurnitureInScene(eventData);
        }
        Destroy(_draggedObject);
    }

    private void PlaceFurnitureInScene(PointerEventData eventData)
    {
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
