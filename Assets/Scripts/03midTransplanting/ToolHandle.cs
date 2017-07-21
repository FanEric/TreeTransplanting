using UnityEngine;
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
        toolManager = GameObject.FindObjectOfType<ToolsManager>();
    }

    // Use this for initialization
    void Start () {
        //GetComponent<Toggle>().onValueChanged.AddListener(OnToolChange);
        GetComponent<Button>().onClick.AddListener(OnButton);
        kDM_A = GameObject.Find("DM_A");
    }

    void OnButton()
    {
        toolManager.kCursorCur = kCursor;
        //1、隐藏上一步骤
        //如果点击的工具对应的步骤大于当前操作步骤的时候隐藏当上一步骤场景
        //反之，则不做其他处理
        int cStep = toolManager.GetCurrentStep();
        //2、显示当前步骤
        for (int i = controledIndex; i < steps.Length; i++)
        {
            if (cStep <= steps[i])
            {
                if (kLastScene != null)
                    kLastScene.SetActive(false);

                controledIndex = i;
                kControledObjs[controledIndex].SetActive(true);
                kLastScene = kControledObjs[controledIndex];
                break;
            }
        }
        //7-10需要隐藏kDM_A
        if (steps[controledIndex] > 7)
        {
            kDM_A.SetActive(false);
        }
        else
        {
            kDM_A.SetActive(true);
        }
    }

    void OnToolChange(bool isOn)
    {
        if (isOn)
        {
            toolManager.kCursorCur = kCursor;
            //1、隐藏上一步骤
            //如果点击的工具对应的步骤大于当前操作步骤的时候隐藏当上一步骤场景
            //反之，则不做其他处理
            int cStep = toolManager.GetCurrentStep();
            //2、显示当前步骤
            for (int i = controledIndex; i < steps.Length; i++)
            {
                if (cStep <= steps[i])
                {
                    if (kLastScene != null)
                        kLastScene.SetActive(false);

                    controledIndex = i;
                    kControledObjs[controledIndex].SetActive(true);
                    kLastScene = kControledObjs[controledIndex];
                    break;
                }
            }
            //7-10需要隐藏kDM_A
            if (steps[controledIndex] > 7)
            {
                kDM_A.SetActive(false);
            }
            else
            {
                kDM_A.SetActive(true);
            }

            //toolManager.kCursorCur = kCursor;
            //for (int i = 0; i < steps.Length; i++)
            //{
            //    if (toolManager.GetCurrentStep() == steps[i])
            //    {
            //        controledIndex = i;
            //        kControledObjs[controledIndex].SetActive(true);
            //        break;
            //    }
            //    else if (toolManager.GetCurrentStep() < steps[i])
            //    {
            //        controledIndex = i;
            //        kControledObjs[controledIndex].SetActive(true);
            //        break;
            //    }
            //}
            ////7-10需要隐藏kDM_A
            //if (steps[controledIndex] > 7 && toolManager.GetCurrentStep() <= steps[controledIndex])
            //{
            //    kDM_A.SetActive(false);
            //}
            //else
            //{
            //    kDM_A.SetActive(true);
            //}
        }
        //else
        //{
        //    Animator[] anims = kControledObjs[controledIndex].GetComponentsInChildren<Animator>();
        //    for (int i = 0; i < anims.Length; i++)
        //    {
        //        anims[i].enabled = false;
        //    }
        //    Debug.Log("toolManager.GetCurrentStep(): " + toolManager.GetCurrentStep());
        //    Debug.Log("steps[controledIndex]: " + steps[controledIndex]);
        //    if (toolManager.GetCurrentStep() <= steps[controledIndex])
        //    {
        //        kControledObjs[controledIndex].SetActive(false);
        //    }

        //    for (int i = steps.Length; i > 0; i--)
        //    {
        //        //如果当前工具对应的最大步骤已经操作过了，则隐藏对应的物体
        //        //主要解决kControledObjs有两个，当操作到第二个的时候隐藏的是第一个的问题
        //        //if (toolManager.GetCurrentStep() >= steps[i - 1])
        //        //{
        //        //    kControledObjs[i - 1].SetActive(false);
        //        //    break;
        //        //}
        //        //else
        //        //{
        //        //    kControledObjs[i - 1].SetActive(false);
        //        //}

        //        //尝试下将所有的物体都隐藏
        //        //kControledObjs[i - 1].SetActive(false);

        //    }

        //    //Debug.Log("controledIndex: " + controledIndex);
        //    //kControledObjs[controledIndex].SetActive(false);
        //}

    }
}

