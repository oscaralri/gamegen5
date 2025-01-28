using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // WIN CONDITION
    // tienes 3 objetivos que cumplir, cada uno con su puntuacion necesaria
    // si llegas a los 3 ganas
    // contiene los objetos de una estetica que tiene que haber AestheticType
    // se puede comprobar la win condition cuando se coloca un nuevo objeto (sino update y ya está )

    // AVISOS
    // cada vez que se coloca un objeto hay que avisarle
    // cada vez que se elimina un objeto hay que avisarle 

    [SerializeField] private List<LevelScriptable> _levels;
    private int numLevel = 0;
    private List<AestheticType> _bestTypes;
    private List<AestheticType> _averageTypes;
    private List<AestheticType> _wrongTypes;

    private void Start()
    {
        // TENGO QUE CAMBIARLO A QUE HAY 3 PUNTUACIONES, quizas dejaria las wrong que sirvan para todas pero las otras dos sí que hacer para cada win condition 
        _bestTypes = _levels[numLevel].bestTypes;
        _averageTypes = _levels[numLevel].averageTypes;
        _wrongTypes = _levels[numLevel].wrongTypes;
    }

    public void DecorPlaced(IPlaceableItem placeableItem)
    {
        for(int i = 0; i < _bestTypes.Count; i++)
        {
            //if(placeableItem.aestheticType == _bestTypes[i])

        }

        
    }

    public void DecorErased()
    {
        
    }


}
