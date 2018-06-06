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
            kAnimBJ.enabled = false;

            toolsManager.ShowBeginAfter();
            audioManager.PlayAudio(0, "");
        }
    }
}

