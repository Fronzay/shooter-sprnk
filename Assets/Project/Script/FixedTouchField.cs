using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedTouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector2 touchDist;
    public Vector2 pointerOld;
    public int pointerIndex;
    bool pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
        pointerIndex = eventData.pointerId;
        pointerOld =  eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    private void Update()
    {
        if (pressed)
        {
            if (pointerIndex >= 0 && pointerIndex < Input.touches.Length)
            {
                touchDist = Input.touches[pointerIndex].position - pointerOld;
                pointerOld = Input.touches[pointerIndex].position;
            }
            else
            {
                touchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - pointerOld;
                pointerOld = Input.mousePosition;
            }
        }
        else
        {
            touchDist = new Vector2();
        }
    }
}
