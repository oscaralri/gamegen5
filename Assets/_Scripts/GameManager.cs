using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // WIN CONDITION
    // tienes 3 objetivos que cumplir, cada uno con su puntuacion necesaria
    // si llegas a los 3 ganas
    // contiene los objetos de una estetica que tiene que haber AestheticType
    // se puede comprobar la win condition cuando se coloca un nuevo objeto (sino update y ya está )
    public static GameManager Instance { get; private set; }

    [SerializeField] private List<LevelScriptable> _levels; // aquí guardo los 3 levels que hay
    [SerializeField] private AllActions _allActions;
    public List<ActionRes> _allToDos;
    private int numLevel = 0; 
    [SerializeField] private float _bestAddToScore = 1f;
    [SerializeField] private float _averageAddToScore = 0.5f;
    [SerializeField] private float _wrongAddToScore = -0.5f; 
    public Bin bin;
    private ActionManager _actionManager;
    public Clock clock; 
    public GameObject[] furniture; // table
    public SpriteRenderer background;
    public GameObject[] deactivateOnEnd;
    private bool alreadyEnd = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        _actionManager = gameObject.GetComponent<ActionManager>(); // se llama para pasarle acciones activas y luego este ya se encarga de ejecutar efectos y tal
        _allToDos = new List<ActionRes>{_levels[numLevel].toDo1, _levels[numLevel].toDo2, _levels[numLevel].toDo3};
    }


    public void DecorPlaced(IPlaceableItem placeableItem)
    {
        foreach(var action in _allActions.allActions) // esto pasa por todas las acciones posibles en el juego
        {
            AddCheckItemInAction(placeableItem, action);
        }
    }

    public void DecorErased(IPlaceableItem placeableItem)
    {
        foreach(var action in _allActions.allActions) 
        {
            MinusCheckItemInAction(placeableItem, action);
        }
    }

    private void AddCheckItemInAction(IPlaceableItem placeableItem, ActionRes action)
    {
        // bestType
        for(int i = 0; i < action.bestTypes.Count; i++) 
        {
            if(placeableItem.aestheticType == action.bestTypes[i])
            {
                action.currentScore += _bestAddToScore;
            }
        }

        // avgType
        for(int i = 0; i < action.averageTypes.Count; i++)
        {
            if(placeableItem.aestheticType == action.averageTypes[i])
            {
                action.currentScore += _averageAddToScore;
            }
        }

        // wrongType
        for(int i = 0; i < action.wrongTypes.Count; i++)
        {
            if(placeableItem.aestheticType == action.wrongTypes[i])
            {
                //if(action.currentScore > 0) 
                action.currentScore -= _wrongAddToScore;
            }
        }

        if(action.currentScore >= action.scoreToReach && action.isActive == false) 
        {
            Debug.Log("accion ha llegado a scoreReach" + action);
            _actionManager.AddActiveAction(action); 
            action.isActive = true;
        }
    }

    private void MinusCheckItemInAction(IPlaceableItem placeableItem, ActionRes action)
    {
        // bestType
        for(int i = 0; i < action.bestTypes.Count; i++) 
        {
            if(placeableItem.aestheticType == action.bestTypes[i])
            {
                action.currentScore -= _bestAddToScore;
            }
        }

        // avgType
        for(int i = 0; i < action.averageTypes.Count; i++)
        {
            if(placeableItem.aestheticType == action.averageTypes[i])
            {
                action.currentScore -= _averageAddToScore;
            }
        }

        // wrongType
        for(int i = 0; i < action.wrongTypes.Count; i++)
        {
            if(placeableItem.aestheticType == action.wrongTypes[i])
            {
                action.currentScore += _wrongAddToScore;
            }
        }

        if(action.currentScore < action.scoreToReach) 
        {
            Debug.Log("accion " + action);
            _actionManager.RemoveActiveAction(action); 
            action.isActive = false;
        }
    }

    public void EndLevel()
    {
        for(int i = 0; i < deactivateOnEnd.Length; i++)
        {
            deactivateOnEnd[i].SetActive(false);
        }

        if(clock.currentTimeInSeconds / 3600 == 0 && alreadyEnd == true)
        {
            Debug.Log("end");
            SceneManager.LoadScene("Menu");
        }
        else if(clock.currentTimeInSeconds / 3600 == 0 && alreadyEnd != true)
        {
            for(int i = 0; i < UIManager.Instance.sprites.Length; i++)
            {
                UIManager.Instance.sprites[i].SetActive(true);
            }
            alreadyEnd = true;
        }
    }
}
