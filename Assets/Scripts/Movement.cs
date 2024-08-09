using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    bool isPressed = false;
    public float speed;
    public GameObject Player;

    private void Update()
    {
        if (isPressed)
        {
            Player.transform.Translate(0,speed,0);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
