using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    private List<TableButton> _tabButtons;
    [SerializeField] private Sprite _tabIdle, _tabHover, _tabActive;
    private TableButton _selectedTab;
    public List<GameObject> pages;

    public void Subscribe(TableButton button)
    {
        if(_tabButtons == null) _tabButtons = new List<TableButton>();
        
        _tabButtons.Add(button);
    }

    public void OnTabEnter(TableButton button)
    {
        ResetTabs();
        if(_selectedTab == null || button != _selectedTab)
        {
            button.background.sprite = _tabHover;
        }
    }
    public void OnTabExit(TableButton button)
    {
        ResetTabs();

    }
    // pages que es padre -> activor hijo del hijo
    public void OnTabSelected(TableButton button)
    {
        _selectedTab = button;
        ResetTabs();
        button.background.sprite = _tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < pages.Count; i++)
        {
            if(i == index) 
            {
                pages[i].SetActive(true);
            }
            else pages[i].SetActive(false);
        }

        for(int i = 0; i < pages.Count; i++)
        {
            GameObject hijo = transform.GetChild(0).gameObject; 
            //nietos = 
        }

    }
/*
    private List<GameObject> ObtainChild()
    {
        List<GameObject> hijos = new List<GameObject>();

        foreach (Transform hijo in padre.transform)
        {
            hijos.Add(hijo.gameObject);
        }

        return hijos;
    }*/

    public void ResetTabs()
    {
        foreach(TableButton button in _tabButtons)
        {
            if(_selectedTab != null && button == _selectedTab) continue;
            button.background.sprite = _tabIdle;
        }
    }

    public void AddPage(GameObject go)
    {
        if(pages == null) pages = new List<GameObject>();
        else pages.Add(go);
    }
}
