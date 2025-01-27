using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    private List<TableButton> _tabButtons;
    [SerializeField] private Sprite _tabIdle, _tabHover, _tabActive;
    private TableButton _selectedTab;
    [SerializeField] private List<GameObject> _pages;

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

    public void OnTabSelected(TableButton button)
    {
        _selectedTab = button;
        ResetTabs();
        button.background.sprite = _tabActive;
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < _pages.Count; i++)
        {
            if(i == index) _pages[i].SetActive(true);
            else _pages[i].SetActive(false);
        }

    }

    public void ResetTabs()
    {
        foreach(TableButton button in _tabButtons)
        {
            if(_selectedTab != null && button == _selectedTab) continue;
            button.background.sprite = _tabIdle;
        }
    }
}
