using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class durdur : MonoBehaviour
{
    public bool durduruldu = false;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public GameObject karartma;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void cikis()
    {
        SceneManager.LoadScene(0);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            durdurmazimbir();
        }
    }
    public void durdurmazimbir()
    {  
            if (!durduruldu)
            {
                pauseMenu.gameObject.SetActive(true);
                durduruldu = true;
                Time.timeScale = 0;
                Debug.Log("durdu");
                karartma.SetActive(false);
            }
            else
            {
                pauseMenu.gameObject.SetActive(false);
                durduruldu = false;
                Time.timeScale = 1;
                settingsMenu.SetActive(false);
                Debug.Log("devam");

            }
    }
}
