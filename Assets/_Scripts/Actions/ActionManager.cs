using System.Collections;
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
    
    private List<ActionRes> _activeActions; // tiene todas las acciones activas 
    [SerializeField] private ActionsInTime _actionsInTime; // cambiarlo 
    private float _time;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        _activeActions = new List<ActionRes>();
    }

    public void AddActiveAction(ActionRes actionRes)
    {
        _activeActions.Add(actionRes);
        ImprimirLista();
    }

    public void RemoveActiveAction(ActionRes actionRes)
    {
        _activeActions.Remove(actionRes);
        ImprimirLista();
    }

    private void Update()
    {
        _time = GameManager.Instance.clock.currentTimeInSeconds; 
        TimeSearch();
    }

    private void TimeSearch()
    {
        int currentTime = Mathf.FloorToInt(_time / 3600);
        for(int i = 0; i < _activeActions.Count; i++)
        {
            if(_activeActions[i].time == currentTime && _activeActions[i].effectScriptable.isExecuted == false)
            {
                _activeActions[i].effectScriptable.isExecuted = true;
                _activeActions[i].effectScriptable.Execute();
                StartCoroutine(UnexecuteActions(_activeActions[i]));
            }
        }
    }

    private IEnumerator UnexecuteActions(ActionRes actionRes)
    {
        yield return new WaitForSeconds(2f);
        actionRes.effectScriptable.isExecuted = false;
    }

    // debug
    private void ImprimirLista()
    {
        for(int i  = 0; i < _activeActions.Count; i++)
        {
            Debug.Log("lista en actionManager  " + _activeActions[i]);

        }
        Debug.Log("----------------------------");
    } 
}
