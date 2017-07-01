using UnityEngine;
using System.Collections;

public class TQCheck : BaseStepDragCheck
{
    public Animator kAnim;
    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        yield return new WaitForSeconds(cClip.length);

    }

    public override bool CheckStep()
    {
        return toolsManager.CheckStep(5);
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x > 0.522f)
            return true;
        return false;
    }
}

