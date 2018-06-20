using UnityEngine;
using System.Collections;

//1、在雪松树干阴面画圈编号1
public class HuaYuanCheck : BaseStepCheck
{
    public Animator kAnimBJ;
    public Animator kAnimMSHQ;

    public override IEnumerator DoStep()
    {
        HideCollider();
        kAnimBJ.enabled = true;
        kAnimMSHQ.enabled = true;

        AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        audioManager.PlayAudio(3002, "移植前1-2天，根据土壤干湿情况进行适当浇水");
    }
}

