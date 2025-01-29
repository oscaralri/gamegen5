using System.Collections.Generic;
using System.Security.Cryptography;
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

    [SerializeField] private List<LevelScriptable> _levels; // aquí guardo los 3 levels que hay
    private int numLevel = 0; // esto quizás se lo pasa gameInit o algo, sino segurament sea uno después de otro pero para poder pausar / salir etc. 
    [SerializeField] private float _bestAddToScore = 1f;
    [SerializeField] private float _averageAddToScore = 0.5f;
    [SerializeField] private float _wrongAddToScore = -0.5f; 
    private List<float> _scoresToReach; // 0.todo1 1.todo2 2.todo3
    private List<List<ActionRes>> _allToDos; 
    private List<float> _scores;


    private void Start()
    {
        _scoresToReach = new List<float> {_levels[numLevel].toDo1[0].scoreToReach,  _levels[numLevel].toDo2[0].scoreToReach, _levels[numLevel].toDo3[0].scoreToReach}; //puntuaciones que llegar de cada todo
        _allToDos = new List<List<ActionRes>> {_levels[numLevel].toDo1, _levels[numLevel].toDo2, _levels[numLevel].toDo3};
    }

    public void DecorPlaced(IPlaceableItem placeableItem)
    {
        int cont = 0;
        foreach(var toDo in _allToDos) // para cada toDo
        {
            AddCheckItemInAction(placeableItem, toDo, cont);
            cont++;
        }    
    }

    public void DecorErased(IPlaceableItem placeableItem)
    {
        int cont = 0;
        foreach(var toDo in _allToDos) // para cada toDo
        {
            MinusCheckItemInAction(placeableItem, toDo, cont);
            cont++;
        } 
    }

    private void AddCheckItemInAction(IPlaceableItem placeableItem, List<ActionRes> toDo, int cont)
    {
        // bestType
        for(int i = 0; i < toDo[0].bestTypes.Count; i++) 
        {
            if(placeableItem.aestheticType == toDo[0].bestTypes[i])
            {
                _scores[cont] += _bestAddToScore;
                if(_scores[cont] == _scoresToReach[cont]) Debug.Log("accion " + toDo[0]);// ejecutar esa accion ligada al todo
            }
        }

        // avgType
        for(int i = 0; i < toDo[0].averageTypes.Count; i++)
        {
            if(placeableItem.aestheticType == toDo[0].averageTypes[i])
            {
                _scores[cont] += _averageAddToScore;
            }
        }

        // wrongType
        for(int i = 0; i < toDo[0].wrongTypes.Count; i++)
        {
            if(placeableItem.aestheticType == toDo[0].wrongTypes[i])
            {
                _scores[cont] += _wrongAddToScore;
            }
        }
    }

    private void MinusCheckItemInAction(IPlaceableItem placeableItem, List<ActionRes> toDo, int cont)
    {
        // bestType
        for(int i = 0; i < toDo[0].bestTypes.Count; i++) 
        {
            if(placeableItem.aestheticType == toDo[0].bestTypes[i])
            {
                _scores[cont] -= _bestAddToScore;
            }
        }

        // avgType
        for(int i = 0; i < toDo[0].averageTypes.Count; i++)
        {
            if(placeableItem.aestheticType == toDo[0].averageTypes[i])
            {
                _scores[cont] -= _averageAddToScore;
            }
        }

        // wrongType
        for(int i = 0; i < toDo[0].wrongTypes.Count; i++)
        {
            if(placeableItem.aestheticType == toDo[0].wrongTypes[i])
            {
                _scores[cont] -= _wrongAddToScore;
            }
        }
    }
}
