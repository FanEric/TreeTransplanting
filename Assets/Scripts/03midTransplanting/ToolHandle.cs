﻿using UnityEngine;
using UnityEngine.UI;

public class ToolHandle : MonoBehaviour {
    public Texture2D kCursor;
    public GameObject[] kControledObjs;
    public int[] steps;
    private int controledIndex;

    public static GameObject kLastScene;

    private GameObject kDM_A;

    ToolsManager toolManager;
    // Use this for initialization
    void Awake()
    {
        toolManager = FindObjectOfType<ToolsManager>();
    }

    // Use this for initialization
    void Start () {
        GetComponent<Button>().onClick.AddListener(OnButton);
        kDM_A = GameObject.Find("DM_A");
    }

    void OnButton()
    {
        toolManager.kCursorCur = kCursor;
        
        int cStep = toolManager.GetCurrentStep();

        if ((controledIndex + 1) <= steps.Length && toolManager.CheckStep(steps[controledIndex]))     //操作步骤正确
        {
            //隐藏上一步场景
            if (kLastScene != null)
                kLastScene.SetActive(false);
            //显示当前步骤
            //controledIndex = cStep - 1;
            kControledObjs[controledIndex].SetActive(true);
            kLastScene = kControledObjs[controledIndex];
            //步骤7以后需要隐藏kDM_A
            if (kDM_A != null)
            {
                if (steps[controledIndex] >= 7)
                    kDM_A.SetActive(false);
                else
                    kDM_A.SetActive(true);
            }
            controledIndex++;
        }
        else    //操作步骤错误
        {
            toolManager.CheckStep(-1);
            toolManager.kMotion.transform.SetParent(transform);
            toolManager.kMotion.transform.localPosition = new Vector3(0, 200, 0);
            toolManager.kMotion.Show();
            toolManager.GetComponent<AudioSource>().Play();
        }
    }
}

