using UnityEngine;
using System.Collections;

public class YQTCheck : BaseStepCheck
{
    public Animator kAnim;
    public Texture2D kCursor;

    public override IEnumerator DoStep()
    {
        //if (toolsManager.CheckStep(1))
        {
            base.GeneralOperOnCheckRight();
            kAnim.enabled = true;

            AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
            toolsManager.SetAnimating(true);
            yield return new WaitForSeconds(cClip.length);
            toolsManager.SetAnimating(false);
            HideAll(transform.parent);

            toolsManager.kCursorCur = kCursor;
        }
    }
}

