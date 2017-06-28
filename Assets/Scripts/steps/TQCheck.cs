using UnityEngine;
using System.Collections;

public class TQCheck : BaseStepDragCheck
{
    public Animator kAnim;
    public override IEnumerator DoStep()
    {
        if (toolsManager.CheckStep(5))
        {
            GetComponent<Collider>().enabled = false;
            kAnim.enabled = true;
            AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
            yield return new WaitForSeconds(cClip.length);
        }
    }
}

