using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for Image component

public class Menu : MonoBehaviour
{
    // Reference to the Image component used for the fade effect
    public Image fadeImage;
    public float fadeDuration = 1f; // Duration of the fade-out effect

    // Flag to indicate if the fade is in progress
    private bool isFading = false;


    [Header("Settings Section")]
    [SerializeField] private GameObject settingGm;
    

    // Load the level with fade effect
    public void LoadLevel()
    {
        if (isFading) return; // Prevent starting a new fade if one is already in progress
        
        Debug.Log("click");

        // Start fade-out and load the scene after fade is complete
        StartCoroutine(FadeAndLoadScene());
    }

    // Coroutine to handle the fade-out and scene loading
    private IEnumerator FadeAndLoadScene()
    {
        // Start the fade to black
        isFading = true;
        fadeImage.gameObject.SetActive(true);
        Color startColor = fadeImage.color;
        startColor.a = 0f;
        fadeImage.color = startColor;

        // Fade out to black
        float timeElapsed = 0f;
        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            startColor.a = Mathf.Clamp01(timeElapsed / fadeDuration); // Increase alpha to 1
            fadeImage.color = startColor;
            yield return null;
        }

        // Fade complete, load the next scene
        int loadVal;
        if ((loadVal = SceneManager.GetActiveScene().buildIndex) == 0)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(loadVal + 1);
    }

    // Quit the game with an editor exception for Unity Editor
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ensure the fade image is not visible at the start
        fadeImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Settings(){
        gameObject.SetActive(false);
        settingGm.SetActive(true);
    }
}
