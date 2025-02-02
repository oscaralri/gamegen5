using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance;
    public List<ActionRes> actionsToAdd;
    
    public List<ActionRes> _activeActions; 
    private float _time;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }

    private void Start()
    {
        _activeActions = new List<ActionRes>();
        for(int i = 0; i < actionsToAdd.Count; i++)
        {
            _activeActions.Add(actionsToAdd[i]);
        }
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
        CheckWinCon();
    }


    private void CheckWinCon()
    {
        int contToWin = 0;
        for(int i = 0; i < _activeActions.Count; i++)
        {
            if(_activeActions[i]  == GameManager.Instance._allToDos[0])
            {
                contToWin++;
            }

            if(_activeActions[i]  == GameManager.Instance._allToDos[1]) contToWin++;
            

            if(_activeActions[i]  == GameManager.Instance._allToDos[2]) contToWin++;
        }


        if(contToWin == 3)
        {
            GameManager.Instance.EndLevel();
        }
    }

/*
    private void TimeSearch()
    {
        int currentTime = Mathf.FloorToInt(_time / 3600);
        ActionRes currentAction = null;
        float lastScore = -1f;

        for(int i = 0; i < _activeActions.Count; i++)
        {
            if(_activeActions[i].time == currentTime && _activeActions[i].effectScriptable.isExecuted == false && _activeActions[i].currentScore > lastScore)
            {
                lastScore = _activeActions[i].currentScore;
                currentAction = _activeActions[i];
            }
        }

        if(currentAction != null)
        {
            currentAction.effectScriptable.isExecuted = true;
            currentAction.effectScriptable.Execute();
            StartCoroutine(UnexecuteActions(currentAction, currentTime));
        }
        
    }
*/
    private void TimeSearch()
    {
        int currentHours = Mathf.FloorToInt(_time / 3600); 
        int currentMinutes = Mathf.FloorToInt((_time % 3600) / 60); 

        ActionRes currentAction = null;
        float lastScore = -1f;

        for (int i = 0; i < _activeActions.Count; i++)
        {
            // para el outfit
            if(_activeActions[i].isOutfit)
            {
                _activeActions[i].effectScriptable.isExecuted = true;
                _activeActions[i].effectScriptable.Execute();
                StartCoroutine(UnexecuteActions(_activeActions[i], currentHours));
            }
            // resto
            else if (_activeActions[i].time == currentHours && _activeActions[i].minutes == currentMinutes &&
                !_activeActions[i].effectScriptable.isExecuted && _activeActions[i].currentScore > lastScore)
            {
                lastScore = _activeActions[i].currentScore;
                currentAction = _activeActions[i];
            }
        }

        if (currentAction != null)
        {
            currentAction.effectScriptable.isExecuted = true;
            currentAction.effectScriptable.Execute();
            StartCoroutine(UnexecuteActions(currentAction, currentHours));
        }
    }
    private IEnumerator UnexecuteActions(ActionRes actionRes, int executedHour)
    {
        while(Mathf.FloorToInt(_time / 3600) == executedHour)
        {
            yield return null;
        }
        Debug.Log("puesto a falso " + actionRes.actionID);
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
