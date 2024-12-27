using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    // Reference to the TMP_Text component to display the timer
    public TMP_Text timerText;
    
    // Variables to store the current and highest times
    private float currentTime = 0f;
    private float highestTime = 0f;

    // Flag to control when the timer should stop
    private bool isTiming = true;

    // PlayerPrefs key to store the highest time
    private string highestTimeKey = "HighestTime";

    void Start()
    {
        // Load the highest time from PlayerPrefs
        highestTime = PlayerPrefs.GetFloat(highestTimeKey, 0f);
    }

    void Update()
    {
        // Only update the timer if we are still timing
        if (isTiming)
        {
            // Increment current time by the delta time
            currentTime += Time.deltaTime;

            // Update the timer display
            timerText.text = "Time: " + currentTime.ToString("F2");
        }
    }

    // Call this function to stop the timer and update the highest score if needed
    public void StopTime()
    {
        isTiming = false; // Stop the timer

        // Check if the current time is higher than the highest time
        if (currentTime > highestTime)
        {
            // Update the highest time in PlayerPrefs
            highestTime = currentTime;
            PlayerPrefs.SetFloat(highestTimeKey, highestTime);
            PlayerPrefs.Save(); // Save changes to PlayerPrefs

            Debug.Log("New Highest Time: " + highestTime);
        }
        else
        {
            Debug.Log("Timer stopped. Current time is not higher than the highest time.");
        }

        // Optionally, you can display the highest time as well
        Debug.Log("Highest Time: " + highestTime);
    }

    // You can reset the timer if needed
    public void ResetTimer()
    {
        currentTime = 0f;
        isTiming = true; // Start the timer again
    }
}
