using UnityEngine;
using System.Collections;

//24 拖动营养液袋子挂到树上，拖动插头到树洞中
public class YYYCheck : BaseStepCheck
{
    public GameObject kTarget;

    public override IEnumerator DoStep()
    {
        base.GeneralOperOnCheckRight();
        kTarget.GetComponent<MeshRenderer>().enabled = true;

        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(2f);
        toolsManager.SetAnimating(false);

        //audioManager.PlayAudio(3023, "注射营养液补充营养，0.05-0.1%的硫酸亚铁溶液稀释200-300倍");

    }
}

