using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseStepCheck : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    protected ToolsManager toolsManager;
    protected AudioManager audioManager;

    void Awake()
    {
        toolsManager = FindObjectOfType<ToolsManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    public virtual IEnumerator DoStep()
    {
        yield return 0;
    }

    void OnEnable()
    {
        if (GameInfo.gameMode == GameMode.PRACTICE)
            GetComponent<MeshRenderer>().enabled = true;
    }

    public void HideCollider()
    {
        toolsManager.step++;  //执行操作之后步骤数加一
        GetComponent<Collider>().enabled = false;
        if (GameInfo.gameMode == GameMode.PRACTICE)
            GetComponent<MeshRenderer>().enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(DoStep());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameInfo.gameMode == GameMode.TEST)
        {
            GetComponent<MeshRenderer>().enabled = true; 
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GameInfo.gameMode == GameMode.TEST)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

}

