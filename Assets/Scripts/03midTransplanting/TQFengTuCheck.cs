using UnityEngine;
using System.Collections;

/// <summary>
/// 18、封土
/// </summary>
public class TQFengTuCheck : BaseStepDragCheck
{
    public Animator kAnim;
    public GameObject kTuduidonghua;
    public GameObject kBazisheng;
    public GameObject kZuizhongtiantu1;
    public GameObject kBazisheng_change;

    void Start()
    {
        TransitionTool.Instance.maskingEvent += OnMasking;
        TransitionTool.Instance.maskingOverEvent += OnMaskingOver;
    }

    public override IEnumerator DoStep()
    {
        HideCollider();
        toolsManager.step++;

        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        TransitionTool.Instance.BeginTransition();
    }

    void OnMasking()
    {
        if (gameObject.activeSelf)
        {
            kTuduidonghua.SetActive(false);
            kBazisheng.SetActive(false);
            kZuizhongtiantu1.SetActive(true);
            kBazisheng_change.SetActive(true);
        }
    }

    void OnMaskingOver()
    {
        if (gameObject.activeSelf)
        {
            TransitionTool.Instance.maskingEvent -= OnMasking;
            TransitionTool.Instance.maskingOverEvent -= OnMaskingOver;
            audioManager.PlayAudio(30182, "围堰浇水，（堰的直径要大于土球直径）");
        }
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.z < 2.1405f)
            return true;
        return false;
    }

}

