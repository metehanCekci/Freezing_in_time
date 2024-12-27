using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public GameObject Menus;
    private bool isPaused = false;

    public void HandleEscape(InputAction.CallbackContext context)
    {
        if (context.performed) // Check if the action was performed
        {
            isPaused = !isPaused; // Toggle pause state
            Menus.SetActive(isPaused); // Activate or deactivate menus

            // Pause or resume the game
            Time.timeScale = isPaused ? 0 : 1;
        }
    }

    public void ButtonEscape(){
        isPaused = false;
        Menus.SetActive(false);
        Time.timeScale = 1;
    }
}
