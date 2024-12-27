using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // SceneManager için gerekli kütüphane
using System.Collections;

public class FadeInOut : MonoBehaviour
{
    public Image targetImage; // Saydamlığı değişecek olan Image
    public float fadeInDuration = 2f; // Yavaşça görünür hale gelme süresi
    public float visibleDuration = 2f; // Görünür kaldığı süre
    public float fadeOutDuration = 2f; // Yavaşça kaybolma süresi


    private void Start()
    {
        // Başlangıçta saydam yap
        targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, 0);

        // Fade in ve fade out işlemlerini sırayla başlat
        StartCoroutine(FadeInOutEffect());
    }

    private IEnumerator FadeInOutEffect()
    {
        // Fade In: Saydamlık 0'dan 1'e doğru artacak
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedTime / fadeInDuration);
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Fade In tamamlandıktan sonra tamamen görünür olduğunda biraz bekle
        yield return new WaitForSeconds(visibleDuration);

        // Fade Out: Saydamlık 1'den 0'a doğru azalacak
        elapsedTime = 0f;
        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeOutDuration);
            targetImage.color = new Color(targetImage.color.r, targetImage.color.g, targetImage.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Fade Out tamamlandıktan sonra sahneyi değiştir
        LoadNextScene();
    }

    // Sonraki sahneyi yüklemek için metod
    private void LoadNextScene()
    {
        // nextSceneName değişkeninde belirtilen sahneyi yükler

            SceneManager.LoadScene(1);
        

    }
}
