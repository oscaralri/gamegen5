using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    private float currentTimeInSeconds = 0f;  
    public float timeSpeed = 1f;  

    void FixedUpdate()
    {
        currentTimeInSeconds += Time.fixedDeltaTime * timeSpeed;

        int hours = Mathf.FloorToInt(currentTimeInSeconds / 3600);
        int minutes = Mathf.FloorToInt((currentTimeInSeconds % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60);

        clockText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    // Método para cambiar la velocidad del reloj
    public void SetTimeSpeed(float newSpeed)
    {
        timeSpeed = newSpeed;
    }
}
