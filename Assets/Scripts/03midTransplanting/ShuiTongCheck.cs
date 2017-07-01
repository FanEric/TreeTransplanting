using UnityEngine;
using System.Collections;

public class ShuiTongCheck : BaseStepCheck
{
    public GameObject kST;

    public override IEnumerator DoStep()
    {
        if (toolsManager.CheckStep(3))
        {
            GetComponent<Collider>().enabled = false;
            kST.SetActive(true);

            AnimationClip cClip = kST.GetComponent<Animator>().runtimeAnimatorController.animationClips[0];
            yield return new WaitForSeconds(cClip.length);
        }
    }
}

