using UnityEngine;
using System.Collections;

//21、拖动木块框架到树干1.5m处，拖动木棍到框架下方
public class MBZhiChengCheck : BaseStepCheck
{
    public Animator kAnimBJ;

    public override IEnumerator DoStep()
    {
        HideCollider();
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(1f);
        kAnimBJ.gameObject.SetActive(true);
        toolsManager.SetAnimating(false);

        audioManager.PlayAudio(3021, "缓慢浇水（第一次浇水移植结束后，3-5天内第二次浇水，拌多菌灵稀释500倍液(促进发根及防止根部腐烂)，15-20天内第三次浇水）");
    }
}

