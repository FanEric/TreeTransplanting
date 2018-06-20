using UnityEngine;
using System.Collections;

//23、拖动喷水管对树干及树冠喷水，对应scene24
public class SGPenShuiCheck : BaseStepCheck
{
    public Animator kAnimBJ;

    public override IEnumerator DoStep()
    {
        HideCollider();
        kAnimBJ.enabled = true;

        kAnimBJ.transform.GetChild(0).gameObject.SetActive(true);

        AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        kAnimBJ.enabled = false;
        kAnimBJ.transform.GetChild(0).gameObject.SetActive(false);

        audioManager.PlayAudio(3023, "注射营养液补充营养，0.05-0.1%的硫酸亚铁溶液稀释200-300倍");
    }
}

