﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 铁锹挖沟
/// </summary>
public class TQWaGouCheck : BaseStepDragCheck
{
    public Animator kAnim;
    public GameObject[] kClays;

    void Start()
    {
        TransitionTool.Instance.maskingEvent += OnMasking;
        TransitionTool.Instance.maskingOverEvent += OnMaskingOver;
    }

    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        HideAll(kAnim.transform);
        TransitionTool.Instance.BeginTransition();

    }

    void OnMasking()
    {
        if (gameObject.activeSelf)
        {
            for (int i = 0; i < kClays.Length; i++)
            {
                kClays[i].SetActive(false);
            }
        }
    }

    void OnMaskingOver()
    {
        if (gameObject.activeSelf)
        {
            toolsManager.ShowQuestion();
            TransitionTool.Instance.maskingEvent -= OnMasking;
            TransitionTool.Instance.maskingOverEvent -= OnMaskingOver;
        }
    }

    void OnDestroy()
    {
        
    }

    //public override bool CheckStep()
    //{
    //    return toolsManager.CheckStep(8);
    //}

    public override bool CheckDistance()
    {
        if (transform.localPosition.z > 0.3f)
            return true;
        return false;
    }

    public void GotoNextStep()
    {
        audioManager.PlayAudio(3008, "在球面下四分之一高度处用草绳水平进行包扎10-15圈，约20-25公分宽");
    }
}

