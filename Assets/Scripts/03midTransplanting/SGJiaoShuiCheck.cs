using UnityEngine;
using System.Collections;

//19、围堰浇水
public class SGJiaoShuiCheck : BaseStepCheck
{
    public Animator kAnimBJ;

    public override IEnumerator DoStep()
    {
        //if (toolsManager.CheckStep(2))
        {
            base.GeneralOperOnCheckRight();
            kAnimBJ.enabled = true;

            AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
            toolsManager.SetAnimating(true);
            yield return new WaitForSeconds(cClip.length);
            toolsManager.SetAnimating(false);

            //audioManager.PlayAudio(3002, "移植前1-2天，根据土壤干湿情况进行适当浇水");
        }
    }
}

