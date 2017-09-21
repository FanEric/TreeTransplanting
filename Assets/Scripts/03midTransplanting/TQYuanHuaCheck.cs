using UnityEngine;
using System.Collections;

/// <summary>
/// 10、拖动铁锹到球的上部
/// </summary>
public class TQYuanHuaCheck : BaseStepDragCheck
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
            TransitionTool.Instance.maskingEvent -= OnMasking;
            TransitionTool.Instance.maskingOverEvent -= OnMaskingOver;
            GotoNextStep();
        }
    }

    void OnDestroy()
    {
       
    }

    //public override bool CheckStep()
    //{
    //    return toolsManager.CheckStep(11);
    //}

    public override bool CheckDistance()
    {
        if (transform.localPosition.y < 0.9f)
            return true;
        return false;
    }

    public void GotoNextStep()
    {
        audioManager.PlayAudio(3011, "将草绳一端固定在树干上，从上到下倾斜缠绕；第二层与第一层交叉压花缠绕");
    }
}

