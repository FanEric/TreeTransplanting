using UnityEngine;
using System.Collections;

/// <summary>
/// 14、拖动绳子到树体根部
/// </summary>
public class CSRootCheck : BaseStepDragCheck
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

        audioManager.PlayAudio(3015, "装车时，树冠向后，土球向前放在车辆上，在土球两旁垫木板或砖块，防止土球滚动");
    }

    void OnDestroy()
    {
       
    }

    //public override bool CheckStep()
    //{
    //    return toolsManager.CheckStep(14);
    //}

    public override bool CheckDistance()
    {
        if (transform.localPosition.z > 0.05f)
            return true;
        return false;
    }

    public void GotoNextStep()
    {
    }
}

