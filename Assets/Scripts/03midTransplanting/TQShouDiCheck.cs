using UnityEngine;
using System.Collections;

/// <summary>
/// 铁锹收底
/// </summary>
public class TQShouDiCheck : BaseStepDragCheck
{
    public Animator kAnim;
    public GameObject[] kClays;

    void Start()
    {
        TransitionTool.Instance.maskingEvent += OnMasking;
        TransitionTool.Instance.maskingOverEvent += OnMaskingOver;
    }

    public override IEnumerator DoStep()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        kAnim.enabled = true;
        AnimationClip cClip = kAnim.runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        HideAll(kAnim.transform);
        TransitionTool.Instance.BeginTransition();

    }

    void OnMasking()
    {
        if (gameObject.activeSelf)
        {
            for (int i = 0; i < kClays.Length; i++)
            {
                kClays[i].SetActive(false);
            }
        }
    }

    void OnMaskingOver()
    {
        if (gameObject.activeSelf)
        {
            toolsManager.ShowQuestion();
            TransitionTool.Instance.maskingEvent -= OnMasking;
            TransitionTool.Instance.maskingOverEvent -= OnMaskingOver;
        }
    }

    void OnDestroy()
    {
       
    }

    public override bool CheckStep()
    {
        return toolsManager.CheckStep(10);
        //return true;
    }

    public override bool CheckDistance()
    {
        if (transform.localPosition.y < 0.9f)
            return true;
        return false;
    }

    public void GotoNextStep()
    {
        audioManager.PlayAudio(3010, "将土球从上到下修整成上大下小圆滑的球状");
    }
}

