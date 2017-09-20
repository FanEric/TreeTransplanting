using UnityEngine;
using System.Collections;

/// <summary>
/// 卷尺（高度）
/// </summary>
public class JCCheck : BaseStepDragCheck {
    public Animator kAnim;
    public GameObject kMark;
    public GameObject kJT2;
    public GameObject kJC2;

    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(2f);
        //yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        HideAll(kAnim.transform);
        kMark.SetActive(true);
        kJT2.SetActive(true);
        kJC2.SetActive(true);
    }

    public override bool CheckStep()
    {
        return toolsManager.CheckStep(6);
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.z > -0.65f)
            return true;
        return false;
    }
}

