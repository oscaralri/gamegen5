using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clockText;
    public float currentTimeInSeconds = 0f;
    public float timeSpeed = 1f;
    private const int SECONDS_IN_A_DAY = 86400; 

    void Update()
    {
        currentTimeInSeconds += Time.deltaTime * timeSpeed;

        int hours = Mathf.FloorToInt(currentTimeInSeconds / 3600);
        int minutes = Mathf.FloorToInt((currentTimeInSeconds % 3600) / 60);

        clockText.text = $"{hours:00}:{minutes:00}";

        if (currentTimeInSeconds >= SECONDS_IN_A_DAY)
        {
            currentTimeInSeconds = 0f;
        }

        
    }
}
