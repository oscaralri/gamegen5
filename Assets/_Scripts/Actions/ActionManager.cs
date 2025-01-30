using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    // recibe el objeto que se ha colocado
    // comprueba si las combinaciones realizan alguna accion

    // el problema es: cada accion necesita x 

    // ESTA CLASE LO QUE QUIERO QUE SE ENCARGUE ES DE TENIENDO LAS ACCIONES ACTIVAS, CUANDO LLEGAN LAS HORAS EN LAS QUE SE ACTIVAN, LLAMAR A LOS EFECTOS CORRESPONDIENTES 
    //  PARA QUE PASE LO QUE TENGA QUE PASAR CUANDO ESTAN ACTIVAS

    public static ActionManager Instance;
    
    private List<Enums.ActionType> _activeActions; // tiene todas las acciones activas 
    [SerializeField] private ActionsInTime _actionsInTime; //cambiarlo 

    // va a tener que haber una lista con TODAS las acciones
        // cómo voy a comprobar (al menos) cada vez que se añade un objeto que cumple con alguna condicion de las acciones 

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        _activeActions = new List<Enums.ActionType>();
    }

    public void AddActiveAction(Enums.ActionType actionType)
    {
        _activeActions.Add(actionType);
    }

    public void RemoveActiveAction(Enums.ActionType actionType)
    {
        _activeActions.Remove(actionType);
    }

    private void Update()
    {
        //if x hora
            // comprobar de las acciones activas si tienen esta hora
                // si empatan quedarte con la que más puntuacion

                /*
        if(hora == 3)
        {
            foreach(var actionType in _activeActions) // esto me devuelve un id
            {
                if(actionType == )
            }
        }
        */

    }
}
