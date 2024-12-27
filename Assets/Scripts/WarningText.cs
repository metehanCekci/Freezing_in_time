using UnityEngine;
using TMPro;

public class WarningText : MonoBehaviour
{
    private TMP_Text textMeshPro;

    private float fadeDuration = 2f; // Time to fade in and fade out (in seconds)
    private float fadeTimer = 0f; // Timer to track the fading process

    private bool isFadingIn = false; // Flag to indicate fading in process
    private bool isFadingOut = false; // Flag to indicate fading out process
    private bool isVisible = false; // Flag to track visibility state

    private void Awake()
    {
        textMeshPro = this.gameObject.GetComponent<TMP_Text>();
        SetVisibility(false); // Start invisible
    }

    // This function can be called to start the fade-in and fade-out process
    public void TriggerVisibilityCycle()
    {
        // If the text is not visible, start fading in
        if (!isVisible && !isFadingIn)
        {
            StartFadingIn();
        }
        // If the text is visible and we're not already fading out, start fading out
        else if (isVisible && !isFadingOut)
        {
            StartFadingOut();
        }
    }

    private void Update()
    {
        // Handle the fading in and out
        if (isFadingIn)
        {
            FadeIn();
        }
        else if (isFadingOut)
        {
            FadeOut();
        }
    }

    // Start the fade-in process
    private void StartFadingIn()
    {
        isFadingIn = true;
        fadeTimer = 0f;
        isVisible = true;
    }

    // Start the fade-out process
    private void StartFadingOut()
    {
        isFadingOut = true;
    }

    // Handle the fade-in (increase alpha over time)
    private void FadeIn()
    {
        fadeTimer += Time.deltaTime;
        float alpha = Mathf.Clamp01(fadeTimer / fadeDuration); // Calculate alpha value based on time

        SetAlpha(alpha);

        // Once fade-in is complete, wait for 2 seconds, then start fading out
        if (fadeTimer >= fadeDuration)
        {
            isFadingIn = false;
            fadeTimer = 0f; // Reset fade timer for the next fade
            Invoke("StartFadingOut", 2f); // Wait for 2 seconds before starting fade-out
        }
    }

    // Handle the fade-out (decrease alpha over time)
    private void FadeOut()
    {
        fadeTimer += Time.deltaTime;
        float alpha = Mathf.Clamp01(1 - (fadeTimer / fadeDuration)); // Calculate alpha value to fade out

        SetAlpha(alpha);

        // Once fade-out is complete, set the text invisible and reset everything
        if (fadeTimer >= fadeDuration)
        {
            isFadingOut = false;
            fadeTimer = 0f; // Reset fade timer for the next fade
            SetVisibility(false); // Make the text invisible
            isVisible = false; // Set the visibility state to false
        }
    }

    // Set the alpha value for the text to control its transparency
    private void SetAlpha(float alpha)
    {
        Color color = textMeshPro.color;
        color.a = alpha;
        textMeshPro.color = color;
    }

    // Set the visibility (either visible or invisible)
    private void SetVisibility(bool isVisible)
    {
        Color color = textMeshPro.color;
        color.a = isVisible ? 1f : 0f; // Set the visibility to fully visible or invisible
        textMeshPro.color = color;
    }
}
