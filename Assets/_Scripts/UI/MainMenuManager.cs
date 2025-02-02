using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CanvasEntry
{
    public string key;
    public GameObject canvas;
}

public class MainMenuManager : MonoBehaviour
{
    public List<CanvasEntry> canvasList = new List<CanvasEntry>(); 
    private Dictionary<string, GameObject> canvasDict = new Dictionary<string, GameObject>();

    void Awake()
    {
        foreach (CanvasEntry entry in canvasList)
        {
            if (!canvasDict.ContainsKey(entry.key))
                canvasDict.Add(entry.key, entry.canvas);
        }
    }

    private void Start()
    {
        SoundManager.Instance.PlayMusic("Menu");
    }

    public void ChangeCanvas(string name)
    {
        foreach(KeyValuePair<string, GameObject> canvas in canvasDict)
        {
            if(canvas.Key == name) canvas.Value.gameObject.SetActive(true);
            else
            {
                canvas.Value.gameObject.SetActive(false);
            }
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
