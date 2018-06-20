using UnityEngine;
using System.Collections;

//2、拖动水桶浇水
public class ShuiTongCheck : BaseStepCheck
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

        audioManager.PlayAudio(3003, "移植前修剪树冠，剪时一般的落叶树抽稀强截，留生长枝和萌生的强壮枝，修剪量6 / 10 - 9 / 10；常绿阔叶树截取外围枝条，抽稀弱枝，修剪量1 / 3 - 3 / 5；“针叶树抽稀树冠外围枝，修剪量1 / 5 - 2 / 5；10cm以上的大伤口应剪平，还需消毒涂保护剂");
    }
}

