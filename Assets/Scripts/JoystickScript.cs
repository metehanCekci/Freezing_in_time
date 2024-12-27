using UnityEngine;
using UnityEngine.EventSystems;

public class TouchJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Joystick Settings")]
    [SerializeField] private RectTransform joystickBackground; // Joystick arka planı
    [SerializeField] private RectTransform joystickHandle; // Joystick kolu
    [SerializeField] private float joystickRadius = 50f; // Joystick'in ne kadar hareket edebileceği (yarıçap)

    private Vector2 joystickInput; // Joystick'in x ve y hareketi
    private Vector2 joystickCenter; // Joystick'in merkez noktası

    void Start()
    {
        // Joystick'in merkezini başlangıçta belirle
        joystickCenter = joystickBackground.position;
        joystickHandle.position = joystickCenter; // Joystick kolunu merkeze yerleştir
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Pointer başladığında joystick'in merkezi güncellenir
        joystickHandle.position = eventData.position; // Kolun başlangıçta parmakla geldiği pozisyona yerleştir
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Joystick'in kolunu sürüklerken, kolu pointer'ın pozisyonuna göre hareket ettiririz
        Vector2 direction = eventData.position - joystickCenter;
        joystickInput = Vector2.ClampMagnitude(direction, joystickRadius) / joystickRadius;

        // Joystick kolunu sınırlı alanda hareket ettir
        joystickHandle.position = joystickCenter + joystickInput * joystickRadius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Parmak kaldırıldığında joystick kolu merkeze geri dönsün
        joystickInput = Vector2.zero;
        joystickHandle.position = joystickCenter; // Kol, merkeze geri döner
    }

    // Joystick'in input'unu almak için bir getter fonksiyonu
    public Vector2 GetJoystickInput()
    {
        return joystickInput;
    }
}
