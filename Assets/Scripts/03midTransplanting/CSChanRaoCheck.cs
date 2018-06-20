using UnityEngine;
using System.Collections;

/// <summary>
/// 8、打内腰箍
/// </summary>
public class CSChanRaoCheck : BaseStepDragCheck
{
    public Animator kAnim;
    
    public override IEnumerator DoStep()
    {
        HideCollider();
        toolsManager.step++;

        kAnim.enabled = true;
        kAnim.GetComponent<MeshRenderer>().enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        audioManager.PlayAudio(3009, "挖掘到土球的2/3时，收底，底部直径为顶部直径的1/3");
    }
    
    public override bool CheckDistance()
    {
        if (transform.localPosition.z < 0f)
            return true;
        return false;
    }
}

