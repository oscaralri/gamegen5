using Unity.VisualScripting;
using UnityEngine;

public class DraggableCollisions : MonoBehaviour
{
    public bool isPlaceable = false;

    // debug
    Color debugMaterial;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<IPlaceableSpot>() != null)
        {
            for(int i = 0; i < gameObject.GetComponentInParent<IconUI>().validSpots.Count; i++)
            {
                if(collider.gameObject.GetComponent<IPlaceableSpot>().spotType == gameObject.GetComponentInParent<IconUI>().validSpots[i])
                {
                    HandleCollision(collider.gameObject);
                }
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.GetComponent<IPlaceableSpot>() != null)
        {
            for(int i = 0; i < gameObject.GetComponentInParent<IconUI>().validSpots.Count; i++)
            {
                if(collider.gameObject.GetComponent<IPlaceableSpot>().spotType == gameObject.GetComponentInParent<IconUI>().validSpots[i])
                {
                    HandleExitCollision(collider.gameObject);
                }
            }
        }
    }

    private void HandleCollision(GameObject spot)
    {
        isPlaceable = true;
        
        debugMaterial = spot.GetComponent<SpriteRenderer>().material.color;

        spot.GetComponent<SpriteRenderer>().material.color = Color.green;
    }

    private void HandleExitCollision(GameObject spot)
    {
        isPlaceable = false; // esto quizás requiere cambios 
        spot.GetComponent<SpriteRenderer>().material.color = debugMaterial;
    }
}
