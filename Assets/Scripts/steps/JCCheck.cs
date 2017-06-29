﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 卷尺s
/// </summary>
public class JCCheck : BaseStepDragCheck {
    public Animator kAnim;
    public GameObject kMark;
    public GameObject kJT2;
    public GameObject kJC2;

    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        yield return new WaitForSeconds(cClip.length);
        //kAnim.gameObject.SetActive(false);
        kMark.SetActive(true);
        kJT2.SetActive(true);
        kJC2.SetActive(true);
    }

    public override bool CheckStep()
    {
        return toolsManager.CheckStep(6);
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.z > -0.48f)
            return true;
        return false;
    }
}

