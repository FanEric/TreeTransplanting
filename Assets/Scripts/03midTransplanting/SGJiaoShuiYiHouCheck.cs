using UnityEngine;
using System.Collections;

//22、拖动浇水管浇水
public class SGJiaoShuiYiHouCheck : BaseStepCheck
{
    public Animator kAnimBJ;

    public override IEnumerator DoStep()
    {
        base.GeneralOperOnCheckRight();
        kAnimBJ.enabled = true;
        for (int i = 0; i < kAnimBJ.transform.childCount; i++)
            kAnimBJ.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;

        AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        kAnimBJ.enabled = false;
        for (int i = 0; i < kAnimBJ.transform.childCount; i++)
            kAnimBJ.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = false;

        audioManager.PlayAudio(3022, "注射营养液补充营养，0.05-0.1%的硫酸亚铁溶液稀释200-300倍");

    }
}

