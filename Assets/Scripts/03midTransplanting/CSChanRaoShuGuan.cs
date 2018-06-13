using UnityEngine;
using System.Collections;

//20、草绳缠绕树干
public class CSChanRaoShuGuan : BaseStepDragReverseCheck
{
    public Animator kAnimBJ;

    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        kAnimBJ.enabled = true;
        kAnimBJ.GetComponent<MeshRenderer>().enabled = true;

        AnimationClip cClip = kAnimBJ.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        kAnimBJ.enabled = false;

        audioManager.PlayAudio(3020, "在树干1.5m高度，用井字形支架对支撑树木");
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.x < -0.16f)
            return true;
        return false;
    }
}

