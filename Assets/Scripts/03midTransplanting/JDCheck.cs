using UnityEngine;
using System.Collections;

public class JDCheck : BaseStepCheck
{
    public Animator kAnim;

    public override IEnumerator DoStep()
    {
        if (toolsManager.CheckStep(4))
        {
            GetComponent<Collider>().enabled = false;
            kAnim.enabled = true;

            AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
            yield return new WaitForSeconds(cClip.length);
        }
    }
}

