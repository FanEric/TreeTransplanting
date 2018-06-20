using UnityEngine;
using System.Collections;

/// <summary>
/// 5-2、卷尺（胸径）
/// </summary>
public class JC2Check : BaseStepDragCheck {
    public Animator kAnim;
    public GameObject kMark;

    public override IEnumerator DoStep()
    {
        HideCollider();
        transform.GetChild(0).gameObject.SetActive(false);
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(1.5f);
        //yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        kMark.SetActive(true);
        toolsManager.ShowQuestion();
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x > 0.350f)
            return true;
        return false;
    }

    public void GotoNextStep()
    {
        audioManager.PlayAudio(3006, "根据之前确定的土球直径，按其半径（半径为105）确定4个点，并连成圆圈");
        toolsManager.step++;
    }
}

