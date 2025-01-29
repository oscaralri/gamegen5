using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    // recibe el objeto que se ha colocado
    // comprueba si las combinaciones realizan alguna accion

    // el problema es: cada accion necesita x 


    public static ActionManager Instance;
    
    private List<Enums.ActionType> _activeActions; // tiene todas las acciones activas 

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    public void RegisterObj()
    {
        // llamar aquí también a gamemanager el DecorPlaced
    }

    public void UnregisterObj()
    {
        // llamar aqui gamemanager
    }

    private void Update()
    {
        //if x hora
            // comprobar de las acciones activas si tienen esta hora
                // si empatan quedarte con la que más puntuacion

    }
}
