using UnityEngine;
using System.Collections;

public class YQTCheck : BaseStepCheck
{
    public Animator kAnim;
    public Texture2D kCursor;

    public override IEnumerator DoStep()
    {
        if (toolsManager.CheckStep(1))
        {
            GetComponent<Collider>().enabled = false;
            kAnim.enabled = true;

            AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
            yield return new WaitForSeconds(cClip.length);

            toolsManager.kCursorCur = kCursor;
        }
    }
}

