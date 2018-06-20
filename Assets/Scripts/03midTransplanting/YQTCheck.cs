using UnityEngine;
using System.Collections;

//0、拖动刷子，蘸取油漆，在雪松树干阴面画圈编号1
public class YQTCheck : BaseStepCheck
{
    public Animator kAnim;
    public Texture2D kCursor;

    public override IEnumerator DoStep()
    {
        HideCollider();
        kAnim.enabled = true;

        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        toolsManager.kCursorCur = kCursor;
    }
}

