using UnityEngine;
using System.Collections;

/// <summary>
/// 3|剪刀抽稀
/// </summary>
public class JDCheck : BaseStepCheck
{
    public Animator kAnim;

    public override IEnumerator DoStep()
    {
        HideCollider();
        kAnim.enabled = true;

        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        audioManager.PlayAudio(3004, "铲除根部周围浮土及落叶垃圾等");
    }
}

