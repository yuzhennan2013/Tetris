using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LongPressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Tooltip("The time in seconds required for a press to be considered 'long'.")]
    public float holdTime = 0.5f;

    public UnityEvent onShortClick;
    public UnityEvent onLongPress;

    private bool isPointerDown = false;
    private float timePressed = 0f;
    private bool longPressTriggered = false;

    void Update()
    {
        if (isPointerDown)
        {
            timePressed += Time.deltaTime;
            if (timePressed >= holdTime && !longPressTriggered)
            {
                longPressTriggered = true;
                onLongPress.Invoke();
                // Optional: Stop further actions after long press
                isPointerDown = false; 
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        timePressed = 0f;
        longPressTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;

        // If a long press was not triggered, consider it a short click
        if (!longPressTriggered)
        {
            onShortClick.Invoke();
        }
    }
}
