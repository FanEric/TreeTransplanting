using UnityEngine;
using System.Collections;

//17、拖动吊车，吊起大树放入树坑中
public class RuKengCheck : BaseStepCheck
{
    public GameObject kDiaoche;
    public GameObject kKache;

    public GameObject kScene17;
    public GameObject kScene18;

    void Start()
    {
        //TransitionTool.Instance.maskingEvent += OnMasking;
        //TransitionTool.Instance.maskingOverEvent += OnMaskingOver;
    }

    public override IEnumerator DoStep()
    {
        //if (toolsManager.CheckStep(17))
        {
            base.GeneralOperOnCheckRight();
            kDiaoche.SetActive(true);
            kKache.SetActive(true);
            AnimationClip cClip = kDiaoche.GetComponent<Animator>().runtimeAnimatorController.animationClips[0];
            toolsManager.SetAnimating(true);
            yield return new WaitForSeconds(cClip.length);
            toolsManager.SetAnimating(false);

            audioManager.PlayAudio(3018, "边填土边踏实，让土壤贴近树根不留空隙，填到高于原来地面5cm左右为止，围堰浇水，（堰的直径要大于土球直径）");
            //TransitionTool.Instance.BeginTransition();
        }
    }

    //void OnMasking()
    //{
    //    if (gameObject.activeSelf)
    //    {
    //        kScene17.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
    //        kScene18.SetActive(true);
    //    }
    //}

    //void OnMaskingOver()
    //{
    //    if (gameObject.activeSelf)
    //    {
    //        audioManager.PlayAudio(3018, "边填土边踏实，让土壤贴近树根不留空隙，填到高于原来地面5cm左右为止，围堰浇水，（堰的直径要大于土球直径）");
    //        TransitionTool.Instance.maskingEvent -= OnMasking;
    //        TransitionTool.Instance.maskingOverEvent -= OnMaskingOver;

    //    }
    //}
}

