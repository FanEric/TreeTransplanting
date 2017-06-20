using UnityEngine;
using System.Collections;

public class ShuiTongCheck : BaseStepCheck
{
    public GameObject kST;

    public override void DoStep()
    {
        if (toolsManager.CheckStep(3))
        {
            GetComponent<Collider>().enabled = false;
            kST.SetActive(true);
        }
    }
}

