using UnityEngine;
using System.Collections;

//19、围堰浇水
public class SGJiaoShuiCheck : BaseStepCheck
{
    public Animator kAnimBJ;
    public GameObject[] kTargets;

    public override IEnumerator DoStep()
    {
        base.HideCollider();
        kAnimBJ.enabled = true;
        for (int i = 0; i < kTargets.Length; i++)
            kTargets[i].GetComponent<MeshRenderer>().enabled = true;

        AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        kAnimBJ.enabled = false;
        for (int i = 0; i < kTargets.Length; i++)
            kTargets[i].GetComponent<MeshRenderer>().enabled = false;

        toolsManager.ShowBeginAfter();
        audioManager.PlayAudio(0, "");
    }
}

