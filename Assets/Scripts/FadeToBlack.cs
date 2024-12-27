using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInEffect : MonoBehaviour
{
    public float fadeDuration = 2f; // Efektin süresi (saniye cinsinden).

    private void Start()
    {
        // Başlangıçta tam siyah ekran olacak.
        
        this.gameObject.GetComponent<Image>().color = new Color(this.gameObject.GetComponent<Image>().color.r, this.gameObject.GetComponent<Image>().color.g, this.gameObject.GetComponent<Image>().color.b, 1f);

        // Yavaşça açılmaya başla.
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        // Fade efekti
        while (elapsedTime < fadeDuration)
        {
            // Ekranın rengini şeffaf yapacak şekilde geçiş yap.
            this.gameObject.GetComponent<Image>().color = Color.Lerp(this.gameObject.GetComponent<Image>().color, Color.clear, elapsedTime / fadeDuration);

            elapsedTime += Time.deltaTime;
            yield return null; // Bir sonraki frame'i bekle
        }

        // Tamamen şeffaf olduğunda siyah ekranı tamamen sil.
        this.gameObject.GetComponent<Image>().color = Color.clear;
        this.gameObject.SetActive(false);
    }
}
