using UnityEngine;
using System.Collections;

//22、拖动浇水管浇水，对应scene23
public class SGJiaoShuiYiHouCheck : BaseStepCheck
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

        audioManager.PlayAudio(3022, "对树干及树冠喷水保湿，每2-3天喷水一次");
    }
}

