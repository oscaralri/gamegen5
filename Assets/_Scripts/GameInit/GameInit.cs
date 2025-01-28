using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    [SerializeField] private List<PagesScriptable> _pages;
    [SerializeField] private Transform _pagesParent;
    [SerializeField] private  Vector2 startingPos = new Vector2(0, 0);
    [SerializeField] private int iconsPerRow = 5;
    [SerializeField] private Vector2 iconSpacing = new Vector2(100, 100);
    public TabGroup _tabGroup;

    private void Awake()
    {
        // generate pages for each icon UI
        GenerateIcons();
    }

    private void GenerateIcons()
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            GameObject parent = new GameObject($"Page{i}");
            RectTransform parentRect = parent.AddComponent<RectTransform>();
            parent.transform.SetParent(_pagesParent);
            parentRect.localPosition = Vector3.zero; 

            if(i > 0) parent.SetActive(false);

            _tabGroup.AddPage(parent);

            Vector2 childPos = startingPos;

            for (int j = 0; j < _pages[i].scriptableObjects.Count; j++)
            {
                var scriptableObject = _pages[i].scriptableObjects[j];

                GameObject child = new GameObject(scriptableObject.name);
                RectTransform childRect = child.AddComponent<RectTransform>();
                child.transform.SetParent(parent.transform);
                childRect.sizeDelta = new Vector2(1, 1);

                childRect.anchoredPosition = childPos;

                if ((j + 1) % iconsPerRow == 0)
                {
                    childPos.x = startingPos.x; 
                    childPos.y -= iconSpacing.y; 
                }
                else
                {
                    childPos.x += iconSpacing.x; 
                }

                // Add components
                // image
                var image = child.AddComponent<Image>();
                if (scriptableObject is DecorObjectInfo decorObject)
                {
                    image.sprite = decorObject.Icon; 
                }

                // prefab and decorType
                var iconUI = child.AddComponent<IconUI>();
                iconUI.prefab = scriptableObject.Prefab;
                iconUI.decorType = scriptableObject.DecorType; // quizás no hace falta
            }
        }
    }
}
