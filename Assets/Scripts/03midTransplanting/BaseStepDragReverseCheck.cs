using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class BaseStepDragReverseCheck : MonoBehaviour, IDragHandler
    //, IBeginDragHandler
{
    protected ToolsManager toolsManager;
    protected AudioManager audioManager;

    private bool isDone = false;
    //private bool doneStep = false;

    void Awake()
    {
        toolsManager = GameObject.FindObjectOfType<ToolsManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
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

    public void OnDrag(PointerEventData eventData)
    {
        //if (doneStep)
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
    }

    //public virtual bool CheckStep()
    //{
    //    return false;
    //}


    public virtual bool CheckDistance()
    {
        return false;
    }

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    if (CheckStep())
    //    {
    //        doneStep = true;
    //    }
    //}
}

