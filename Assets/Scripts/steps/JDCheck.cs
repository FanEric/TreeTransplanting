using UnityEngine;

public class JDCheck : BaseStepCheck
{
    public Animator kAnim;

    public override void DoStep()
    {
        if (toolsManager.CheckStep(4))
        {
            GetComponent<Collider>().enabled = false;
            kAnim.enabled = true;
        }
    }
}

