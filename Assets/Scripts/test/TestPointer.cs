using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public delegate void TestDele();

public class TestPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{

    private bool isHover = false;
    private bool isPressed = false;
    float lastMousePosX = 0;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isHover && isPressed)
        {
            Drag();
        }
        else
        {
            lastMousePosX = 0;
        }
	}

    void Drag()
    {
        if (lastMousePosX != 0)
        {
            float rate = Input.mousePosition.x - lastMousePosX;
            transform.Translate(Vector3.forward * rate / 100f, Space.Self);
        }
        lastMousePosX = Input.mousePosition.x;
    }
}

