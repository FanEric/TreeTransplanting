using UnityEngine;
using System.Collections;

public class TQCheck : BaseStepDragCheck
{
    public Animator kAnim;
    public override IEnumerator DoStep()
    {
        HideCollider();
        toolsManager.step++;
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        audioManager.PlayAudio(3005, "根据树木胸径大小确定土球的直径（一般情况下土球直径为胸径的6-8倍）");
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x > 0.300f)
            return true;
        return false;
    }
}

