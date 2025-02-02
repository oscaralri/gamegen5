using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance;
    
    private List<ActionRes> _activeActions; 
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
            

            if(_activeActions[i]  == GameManager.Instance._allToDos[2]);
        }

        Debug.Log("contToWin" + contToWin);

        if(contToWin == 3)
        {
            GameManager.Instance.EndLevel();
        }
    }

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

    private IEnumerator UnexecuteActions(ActionRes actionRes, int executedHour)
    {
        while(Mathf.FloorToInt(_time / 3600) == executedHour)
        {
            yield return new WaitForSeconds(1f);
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
