using UnityEngine;
using UnityEngine.EventSystems;

public class swipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float requiredHoldTime = 0.5f;

    private float pointerDownTimer = 0f;
    private bool isPointerDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void Update()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                Debug.Log("Object was held down!");
                Reset();
            }
        }
    }

    private void Reset()
    {
        isPointerDown = false;
        pointerDownTimer = 0f;
    }
}