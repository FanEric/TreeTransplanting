using UnityEngine;
using System.Collections;

/// <summary>
/// 卷尺
/// </summary>
public class JC2Check : BaseStepDragCheck {
    public Animator kAnim;
    public GameObject kMark;

    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        yield return new WaitForSeconds(cClip.length);

        kMark.SetActive(true);
        //kAnim.gameObject.SetActive(false);
    }

    public override bool CheckStep()
    {
        return true;
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x > 0.512f)
            return true;
        return false;
    }
}

