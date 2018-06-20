using UnityEngine;
using System.Collections;

/// <summary>
/// 6、拖动卷尺在4个方向上测量半径，连成圆圈
/// </summary>
public class QBJCheck : BaseStepDragCheck
{
    public Animator kAnim;

    public override IEnumerator DoStep()
    {
        HideCollider();
        toolsManager.step++;

        transform.GetChild(0).gameObject.SetActive(false);
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        audioManager.PlayAudio(3007, "沿着弧线的外沿，垂直挖掘，沟的宽度一般为30-50cm,深度（土球的高度）为土球直径的2/3");
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x < 0.68f)
            return true;
        return false;
    }
}

