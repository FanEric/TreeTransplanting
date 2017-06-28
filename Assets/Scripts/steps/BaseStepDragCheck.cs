using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class BaseStepDragCheck : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    protected ToolsManager toolsManager;
    protected AudioManager audioManager;

    Vector2 startPos = Vector2.zero;
    private bool isDone = false;

    void Awake()
    {
        toolsManager = GameObject.FindObjectOfType<ToolsManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public virtual IEnumerator DoStep()
    {
        yield return 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.Translate(Vector3.forward * 1f / 100f, Space.Self);
        //Debug.Log("distance: " + Vector2.SqrMagnitude(eventData.position - startPos));
        if (!isDone && (Vector2.SqrMagnitude(eventData.position - startPos)) > 10000f)
        {
            Debug.Log("over!");
            isDone = true;
            StartCoroutine(DoStep());
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
        //Debug.Log("startPos: " + startPos.ToString());
    }

}

