﻿using UnityEngine;
using System.Collections;

public class HuaYuanCheck : BaseStepCheck
{
    public Animator kAnimBJ;
    public Animator kAnimMSHQ;

    //public override void DoStep()
    //{
    //    if (toolsManager.CheckStep(2))
    //    {
    //        GetComponent<Collider>().enabled = false;
    //        kAnimBJ.enabled = true;
    //        kAnimMSHQ.enabled = true;

    //        audioManager.PlayAudio(305, "移植前1-2天，根据土壤干湿情况进行适当浇水");
    //    }
    //}

    public override IEnumerator DoStep()
    {
        if (toolsManager.CheckStep(2))
        {
            GetComponent<Collider>().enabled = false;
            kAnimBJ.enabled = true;
            kAnimMSHQ.enabled = true;

            AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
            yield return new WaitForSeconds(cClip.length);

            audioManager.PlayAudio(305, "移植前1-2天，根据土壤干湿情况进行适当浇水");
        }
    }
}

