using UnityEngine;
using System.Collections;

//17、拖动吊车，吊起大树放入树坑中
public class RuKengCheck : BaseStepCheck
{
    public Animator kAnim;

    public override IEnumerator DoStep()
    {
        HideCollider();
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.GetComponent<Animator>().runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);

        audioManager.PlayAudio(3018, "边填土边踏实，让土壤贴近树根不留空隙，填到高于原来地面5cm左右为止");
    }
}

