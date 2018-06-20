using UnityEngine;
using System.Collections;

/// <summary>
/// 12、拖动草绳到球中间
/// </summary>
public class CSZhongJianCheck : BaseStepDragCheck
{
    public Animator kAnim;

    public override IEnumerator DoStep()
    {
        HideCollider();
        toolsManager.step++;

        kAnim.enabled = true;
        kAnim.GetComponentInChildren<MeshRenderer>().enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);

        audioManager.PlayAudio(3013, "计算土球重量，安排相应的起重工具和运输车辆。W=4/3πr3β*2/3(w-土球的重量；4/3πr3-球体公式；β-土壤容重（一般取1.7-1.8）；2/3体积系数）r=100");
        toolsManager.step++;

        if (GameInfo.gameMode == GameMode.PRACTICE)
            yield return new WaitForSeconds(30f);
        toolsManager.SetAnimating(false);
        //第13步，没有操作，只在界面上显示重量计算
        toolsManager.CheckStep(13);
        audioManager.PlayAudio(3014, "用事先准备好的钢丝绳八字形兜底通过重心，在绳与泥球之间插木板，以防绳子嵌入土球而切断草绳，另一更麻绳系于主干分叉处使树梢倾斜在起吊钩上，并使树干小于45度");
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.z < -0.9f)
            return true;
        return false;
    }

}

