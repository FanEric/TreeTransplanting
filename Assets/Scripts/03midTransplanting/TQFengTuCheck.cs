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
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        HideAll(kAnim.transform);
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
            GotoNextStep();
            TransitionTool.Instance.maskingEvent -= OnMasking;
            TransitionTool.Instance.maskingOverEvent -= OnMaskingOver;
        }
    }

    void OnDestroy()
    {
        
    }

    public override bool CheckStep()
    {
        return toolsManager.CheckStep(18);
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.z < 2.1405f)
            return true;
        return false;
    }

    public void GotoNextStep()
    {
        audioManager.PlayAudio(3019, "为防止水分蒸腾过大，需用草绳包裹从根部至离地2m左右的树干（对草绳浇水保持韧性，草绳间不留空隙）");
    }
}

