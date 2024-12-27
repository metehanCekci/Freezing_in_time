using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class SprintButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    

public bool IsSprinting { get; private set; } = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        IsSprinting = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsSprinting = false;
    }
    
    
}
