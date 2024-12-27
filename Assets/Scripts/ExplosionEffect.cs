using System.Collections;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    // Patlama parametreleri
    public float growthDuration = 1f; // Büyüme süresi
    public float maxScaleMultiplier = 2f; // Maksimum büyüme oranı
    public float fadeDuration = 1f; // Solma süresi
    public float delayBeforeDestroy = 0.5f; // Destroy öncesi gecikme süresi
    public int damage;

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;
    private Color originalColor;

    void Awake()
    {
        // Başlangıç ayarlarını yap
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        originalColor = spriteRenderer.color;

        // Patlama işlemi başlat
        StartCoroutine(ExplosionSequence());
    }

    private IEnumerator ExplosionSequence()
    {
        // 1. Adım: Objeyi büyüt
        float growthTime = 0f;
        while (growthTime < growthDuration)
        {
            float scaleMultiplier = Mathf.Lerp(1f, maxScaleMultiplier, growthTime / growthDuration);
            transform.localScale = originalScale * scaleMultiplier;
            growthTime += Time.deltaTime;
            yield return null;
        }

        // 2. Adım: Objeyi solut (saydamlık kaybı)
        float fadeTime = 0f;
        while (fadeTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, fadeTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            fadeTime += Time.deltaTime;
            yield return null;
        }

        // 3. Adım: Gecikmeli olarak objeyi yok et
        yield return new WaitForSeconds(delayBeforeDestroy);
        Destroy(gameObject);
    }
}
