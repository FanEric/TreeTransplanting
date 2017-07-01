using UnityEngine;
using System.Collections;

/// <summary>
/// 拖动卷尺在4个方向上测量半径，连成圆圈
/// </summary>
public class QBJCheck : BaseStepDragCheck
{
    public Animator kAnim;

    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
    }

    public override bool CheckStep()
    {
        return toolsManager.CheckStep(7);
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x < 0.549f)
            return true;
        return false;
    }
}

