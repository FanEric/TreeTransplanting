using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class BaseStepCheck : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected ToolsManager toolsManager;
    protected AudioManager audioManager;

    void Awake()
    {
        toolsManager = GameObject.FindObjectOfType<ToolsManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public virtual IEnumerator DoStep()
    {
        yield return 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(DoStep());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().enabled = true; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}

