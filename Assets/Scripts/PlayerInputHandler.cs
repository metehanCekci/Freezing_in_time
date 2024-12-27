using System.Threading;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerInputHandler : MonoBehaviour
{
    [Header("Input Actions Asset")]
    [SerializeField] private InputActionAsset playerControls;
    [Header("Actions Map Name Reference")]
    [SerializeField] private string mapName = "Player";
    [SerializeField] private string UImapName = "UI";
    [Header("Actions Name Reference")]
    [SerializeField] private string move = "Move";
    [Header("Actions Name Reference")]
    [SerializeField] private string look = "Look";
    [Header("Actions Name Reference")]
    [SerializeField] private string jump = "Jump";
    [Header("Actions Name Reference")]
    [SerializeField] private string sprint = "Sprint";
    [SerializeField] private string escape = "Escape";

    [Header("Movement Joystick")]
    [SerializeField] private TouchJoystick movementJoystick;
    [SerializeField] private bool isJoystickActive = false;

    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;
    private InputAction escapeAction;
    public bool isPaused = false;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject guiElements;
    [SerializeField] private GameObject CtrlElements;

    public static PlayerInputHandler Instance { get; private set; }

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool JumpTriggered { get; private set; }
    public float SprintValue { get; private set; }
    public bool EscapeTriggered { get; private set; }

    private bool isMobile;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        moveAction = playerControls.FindActionMap(mapName).FindAction(move);
        lookAction = playerControls.FindActionMap(mapName).FindAction(look);
        jumpAction = playerControls.FindActionMap(mapName).FindAction(jump);
        sprintAction = playerControls.FindActionMap(mapName).FindAction(sprint);
        escapeAction = playerControls.FindActionMap(UImapName).FindAction(escape);

        RegisterInputActions();

        isMobile = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
        isJoystickActive = isMobile;
    }

    void Start()
    {
        movementJoystick = GameObject.FindWithTag("MoveJoystick").GetComponent<TouchJoystick>();

        if (movementJoystick != null)
        {
            movementJoystick.gameObject.SetActive(isJoystickActive);
        }

        Application.targetFrameRate = 120;
    }

    void Update()
    {
        if (isJoystickActive)
        {
            Vector2 joystickInput = movementJoystick.GetJoystickInput();
            if (joystickInput.magnitude > 0) MoveInput = joystickInput;
            else MoveInput = Vector2.zero;
        }
    }

    void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        jumpAction.performed += context => JumpTriggered = true;
        jumpAction.canceled += context => JumpTriggered = false;

        sprintAction.performed += context => SprintValue = context.ReadValue<float>();
        sprintAction.canceled += context => SprintValue = 0f;

        escapeAction.performed += Pause;
    }

    void Pause(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
        guiElements.SetActive(true);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Freeze game time
        isPaused = true;
        guiElements.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Reset time scale
        Application.Quit(); // Quit the application
        Debug.Log("Game Quit"); // Useful for testing in the Editor
    }
    void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
        if (SceneManager.GetActiveScene().buildIndex != 0) escapeAction.Enable();
        else escapeAction.Disable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        sprintAction.Disable();
        escapeAction.Disable();
    }
}
