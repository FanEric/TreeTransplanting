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

    /// <summary>
    /// 动画播放完毕之后隐藏
    /// 摒弃不用，改为点击别的工具的时候隐藏
    /// </summary>
    /// <param name="hideParent"></param>
    public void HideAll(Transform hideParent)
    {
        //MeshRenderer[] mrs = hideParent.GetComponentsInChildren<MeshRenderer>();
        //for (int i = 0; i < mrs.Length; i++)
        //{
        //    mrs[i].enabled = false;
        //}
    }

    void OnEnable()
    {
        if (GameInfo.gameMode == GameMode.PRECTICE)
            GetComponent<MeshRenderer>().enabled = true;
    }

    public void GeneralOperOnCheckRight()
    {
        GetComponent<Collider>().enabled = false;
        if (GameInfo.gameMode == GameMode.PRECTICE)
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

