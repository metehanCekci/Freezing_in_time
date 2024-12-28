using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffect : MonoBehaviour
{
    public float fadeDuration = 2f; // The duration of the fade effect (in seconds).
    private Image imageComponent; // Cached reference to the Image component

    private void Start()
    {
        // Cache the Image component for performance.
        imageComponent = this.gameObject.GetComponent<Image>();

        // Start with full opacity (black screen).
        imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 1f);

        // Begin the fade-in effect.
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        // Gradually reduce the opacity to 0 (fade to clear).
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration); // Interpolating between 1 and 0.
            imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final alpha is 0 and disable the object immediately after fading.
        imageComponent.color = new Color(imageComponent.color.r, imageComponent.color.g, imageComponent.color.b, 0f);
        this.gameObject.SetActive(false); // Disable the object as soon as it’s completely faded.
    }
}
