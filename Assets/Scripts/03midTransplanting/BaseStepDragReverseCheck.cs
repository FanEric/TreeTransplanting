using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseStepDragReverseCheck : MonoBehaviour, IDragHandler
{
    protected ToolsManager toolsManager;
    protected AudioManager audioManager;

    private bool isDone = false;

    void Awake()
    {
        toolsManager = FindObjectOfType<ToolsManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnEnable()
    {
        if (GameInfo.gameMode == GameMode.TEST)
            GetComponent<Renderer>().material.SetFloat("_Speed", 0f);
    }

    public virtual IEnumerator DoStep()
    {
        yield return 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!CheckDistance())
        {
            transform.Translate(-Vector3.forward * 1f / 100f, Space.Self);
        }
        else if (!isDone)
        {
            isDone = true;
            StartCoroutine(DoStep());
        }
    }

    public virtual bool CheckDistance()
    {
        return false;
    }

}

