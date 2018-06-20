using UnityEngine;
using System.Collections;

/// <summary>
/// 5-1、卷尺（高度）
/// </summary>
public class JCCheck : BaseStepDragCheck {
    public Animator kAnim;
    public GameObject kMark;
    public GameObject kJT2;
    public GameObject kJC2;

    public override IEnumerator DoStep()
    {
        HideCollider();
        transform.GetChild(0).gameObject.SetActive(false);
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(2f);//原动画的长度为4，但是中间有帧数是空，所以手动改为等待2秒
        //yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        kMark.SetActive(true);
        kJT2.SetActive(true);
        kJC2.SetActive(true);
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.z > -0.65f)
            return true;
        return false;
    }
}

