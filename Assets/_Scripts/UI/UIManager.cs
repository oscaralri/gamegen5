using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPointerClickHandler
{
    public static UIManager Instance {get; set;}
    public List<String> textToShow;
    public TextMeshProUGUI text;
    int i = 0;

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

    }
    

    public void LoadText(List<String> textList)
    {
        i = 0;
        textToShow = textList;
        textToShow.Add("");
    }

    public void ShowText()
    {
        text.text = textToShow[0];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(i + 1 < textToShow.Count) 
        {
            i++;
            text.text = textToShow[i];
        }
    }
}
