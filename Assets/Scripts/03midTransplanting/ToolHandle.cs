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
            if (steps[controledIndex] >= 7)
            {
                kDM_A.SetActive(false);
            }
            else
            {
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

    //void OnButton()
    //{
    //    toolManager.kCursorCur = kCursor;
    //    //1、隐藏上一步骤
    //    //如果点击的工具对应的步骤大于当前操作步骤的时候隐藏当上一步骤场景
    //    //反之，则不做其他处理
    //    int cStep = toolManager.GetCurrentStep();
    //    //2、显示当前步骤
    //    for (int i = controledIndex; i < steps.Length; i++)
    //    {
    //        if (cStep <= steps[i])
    //        {
    //            if (kLastScene != null)
    //                kLastScene.SetActive(false);

    //            controledIndex = i;
    //            kControledObjs[controledIndex].SetActive(true);
    //            kLastScene = kControledObjs[controledIndex];
    //            break;
    //        }
    //    }
    //    //7-10需要隐藏kDM_A
    //    if (steps[controledIndex] > 7)
    //    {
    //        kDM_A.SetActive(false);
    //    }
    //    else
    //    {
    //        kDM_A.SetActive(true);
    //    }
    //}
}

