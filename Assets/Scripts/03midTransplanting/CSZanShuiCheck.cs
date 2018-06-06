using UnityEngine;
using System.Collections;

//20、草绳蘸水
public class CSZanShuiCheck : BaseStepCheck
{
    public Animator kAnimBJ;
    public GameObject kShuguancaosheng;
    //public GameObject kShuguancaoshengCo;

    public override IEnumerator DoStep()
    {
        base.GeneralOperOnCheckRight();
        kAnimBJ.enabled = true;

        AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        kAnimBJ.enabled = false;

        kShuguancaosheng.SetActive(true);
        //kShuguancaoshengCo.SetActive(true);
    }
}

