using UnityEngine;
using System.Collections;

/// <summary>
/// 11、拖动草绳到树干处
/// </summary>
public class CSGuDingCheck : BaseStepDragCheck
{
    public Animator kAnim;

    void Start()
    {
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

        GotoNextStep();
    }

    void OnDestroy()
    {
       
    }

    //public override bool CheckStep()
    //{
    //    return toolsManager.CheckStep(12);
    //}

    public override bool CheckDistance()
    {
        if (transform.localPosition.z > 0.041f)
            return true;
        return false;
    }

    public void GotoNextStep()
    {
        audioManager.PlayAudio(3012, "在土球中间水平缠绕几道腰绳，与内腰箍同宽");
    }
}

