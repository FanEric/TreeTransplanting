using UnityEngine;
using System.Collections;

public class HuaFeiCheck : BaseStepCheck
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

        audioManager.PlayAudio(3017, "树体直立将树放入穴内中央，使土球表面高于种植穴口10公分左右");
    }
}

