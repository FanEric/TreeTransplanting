using UnityEngine;
using System.Collections;

//24 拖动营养液袋子挂到树上，拖动插头到树洞中
public class YYYCheck : BaseStepCheck
{
    public GameObject kTarget;
    public ScoreManager scoreManager;

    public override IEnumerator DoStep()
    {
        HideCollider();
        kTarget.GetComponent<MeshRenderer>().enabled = true;

        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(4f);
        toolsManager.SetAnimating(false);

        scoreManager.OnGameOver();
    }
}

