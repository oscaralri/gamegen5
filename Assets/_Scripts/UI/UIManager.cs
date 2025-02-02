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
    public Image imageSleep;
    public int minTimeSpeed, maxTimeSpeed;
    private float lastSpeed;
    int i = 0;
    public SpriteRenderer currentOutfit;

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

    public void LoadText(List<String> textList)
    {
        i = 0;
        textToShow = new List<string>(textList);
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

    public void ClearText()
    {
        text.text = "";
        textToShow = new List<string>{""};
    }

    public void ChangeSpeed(int num)
    {
        float speedMultiplier = (float)num / 2f; 
        if(minTimeSpeed < GameManager.Instance.clock.timeSpeed * speedMultiplier && GameManager.Instance.clock.timeSpeed * speedMultiplier < maxTimeSpeed + 1)
        {
            GameManager.Instance.clock.timeSpeed *= speedMultiplier;
        }
    }

    public void PauseResumeSpeed()
    {
        if(GameManager.Instance.clock.timeSpeed > 0) 
        {
            lastSpeed = GameManager.Instance.clock.timeSpeed;
            GameManager.Instance.clock.timeSpeed = 0;
        }
        else
        {
            GameManager.Instance.clock.timeSpeed = lastSpeed;
        }

    }

    public void ChangeOutfit(Sprite outfit)
    {
        currentOutfit.sprite = outfit;
    }

}
