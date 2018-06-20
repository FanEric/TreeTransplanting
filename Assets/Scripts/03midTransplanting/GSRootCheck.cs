using UnityEngine;
using System.Collections;

public class GSRootCheck : BaseStepCheck
{
    public GameObject kST;

    public override IEnumerator DoStep()
    {
        HideCollider();
        kST.SetActive(true);

        AnimationClip cClip = kST.GetComponent<Animator>().runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        audioManager.PlayAudio(3015, "装车时，树冠向后，土球向前放在车辆上，在土球两旁垫木板或砖块，防止土球滚动");
    }
}

