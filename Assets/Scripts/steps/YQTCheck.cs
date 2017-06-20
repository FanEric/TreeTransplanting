using UnityEngine;

public class YQTCheck : BaseStepCheck
{
    public Animator kAnim;
    public Texture2D kCursor;

    public override void DoStep()
    {
        if (toolsManager.CheckStep(1))
        {
            GetComponent<Collider>().enabled = false;
            kAnim.enabled = true;
            toolsManager.kCursorCur = kCursor;
        }
    }
}

