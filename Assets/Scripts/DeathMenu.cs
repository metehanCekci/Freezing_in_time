using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for Image component
using System.Collections;

public class DeathMenu : MonoBehaviour
{
    [Header("GUI Elements")]
    [SerializeField] private GameObject guiElements;
    
    [Header("Control Elements")]
    [SerializeField] private GameObject ctrlElements;

    [Header("Settings Section")]
    [SerializeField] private GameObject settingmenu;
    [Header("Menu before Settings")]
    //[SerializeField] private GameObject beforemenu;
    [SerializeField] public GameObject spawnerScriptLeft;
    [SerializeField] public GameObject spawnerScriptRight;
    private bool isSetting = false;
    
    [Header("Fade Elements")]
    [SerializeField] private Image fadeImage; // The Image used for the fade effect
    public float fadeDuration = 1f; // Duration for the fade effect

    private bool isFading = false; // Flag to prevent multiple fade operations

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnerScriptLeft.SetActive(true);
        spawnerScriptRight.SetActive(true);
        guiElements.gameObject.SetActive(false);
        ctrlElements.gameObject.SetActive(false);

        // Ensure the fade image is not visible at the start
        fadeImage.gameObject.SetActive(false);
        spawnerScriptLeft.GetComponent<Spawner>();
        spawnerScriptRight.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        // Any logic needed for update
    }

    public void SettingsPop(){
        isSetting = !isSetting;
        if(isSetting){
            settingmenu.SetActive(true);
            
        }
        else{
            settingmenu.SetActive(false);
            //beforemenu.SetActive(true);
        }
    }

    public void RestartScene()
    {
        StartCoroutine(FadeAndRestartScene());
    }

    public void QuitToMenu()
    {
        if (isFading) return; // Prevent fade if already in progress
        StartCoroutine(FadeAndQuitToMenu());
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    // Coroutine to handle the fade-out and scene reload (restart)
    private IEnumerator FadeAndRestartScene()
    {
        Time.timeScale = 1;
        isFading = true;

        // Start the fade to black
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

        // Once fade is complete, restart the scene
        spawnerScriptLeft.SetActive(false);
        spawnerScriptRight.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    // Coroutine to handle the fade-out and scene transition to the main menu
    private IEnumerator FadeAndQuitToMenu()
    {
        Time.timeScale = 1;
        isFading = true;

        // Start the fade to black
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

        // Once fade is complete, load the main menu
        SceneManager.LoadScene(0);
    }
}
