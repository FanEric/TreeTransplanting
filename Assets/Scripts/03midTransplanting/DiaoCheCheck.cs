﻿using UnityEngine;
using System.Collections;

//15、拖动起重车到画面，吊起土球，装车运输
public class DiaoCheCheck : BaseStepCheck
{
    public GameObject kDiaoChe;
    public GameObject kKache;
    public Animator kBazisheng;
    public GameObject kMainTree;
    public GameObject kOtherTree;
    public GameObject kGrass;
    public GameObject kNewEnvi;

    void Start()
    {
        TransitionTool.Instance.maskingEvent += OnMasking;
        TransitionTool.Instance.maskingOverEvent += OnMaskingOver;
    }

    public override IEnumerator DoStep()
    {
        base.GeneralOperOnCheckRight();
        //kDiaoChe.SetActive(true);
        //kKache.SetActive(true);
        kDiaoChe.GetComponent<Animator>().enabled = true;
        kBazisheng.enabled = true;
        GetComponent<MeshRenderer>().enabled = false;
        kMainTree.SetActive(false);

        AnimationClip cClip = kDiaoChe.GetComponent<Animator>().runtimeAnimatorController.animationClips[0];
        toolsManager.SetAnimating(true);
        yield return new WaitForSeconds(cClip.length);
        toolsManager.SetAnimating(false);
        //动画播放完毕后显示问题
        toolsManager.ShowQuestion();

        //TransitionTool.Instance.BeginTransition();
    }

    void OnMasking()
    {
        if (gameObject.activeSelf)
        {
            kDiaoChe.SetActive(false);
            kKache.SetActive(false);
            kOtherTree.SetActive(false);
            kGrass.SetActive(false);
            kNewEnvi.SetActive(true);
        }
    }

    void OnMaskingOver()
    {
        if (gameObject.activeSelf)
        {
            audioManager.PlayAudio(3016, "在树坑底部撒上适量复合肥与土壤拌匀做为底肥，高度在10-20cm（树坑口径应上下一致，土壤由3份原土一份细沙一份腐质土构成）");
            TransitionTool.Instance.maskingEvent -= OnMasking;
            TransitionTool.Instance.maskingOverEvent -= OnMaskingOver;
        }
    }
}

