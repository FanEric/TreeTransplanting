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
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        HideAll(kAnim.transform);

        audioManager.PlayAudio(3005, "根据树木胸径大小确定土球的直径（一般情况下土球直径为胸径的6-8倍）");
    }

    public override bool CheckStep()
    {
        return toolsManager.CheckStep(5);
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x > 0.300f)
            return true;
        return false;
    }
}

