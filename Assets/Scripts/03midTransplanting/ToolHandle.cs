using UnityEngine;
using UnityEngine.UI;

public class ToolHandle : MonoBehaviour {
    public Texture2D kCursor;
    public Texture2D kCursorSpare;
    public GameObject[] kControledObjs;
    public int[] steps;
    private int controledIndex;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = new Vector2(32, 32);

    ToolsManager toolManager;
    // Use this for initialization
    void Awake()
    {
        toolManager = GameObject.FindObjectOfType<ToolsManager>();
    }

    // Use this for initialization
    void Start () {
        GetComponent<Toggle>().onValueChanged.AddListener(OnToolChange);
	}

    void OnToolChange(bool isOn)
    {
        if (isOn)
        {
            toolManager.kCursorCur = kCursor;
            for (int i = 0; i < steps.Length; i++)
            {
                if (toolManager.GetCurrentStep() == steps[i])
                {
                    controledIndex = i;
                    kControledObjs[controledIndex].SetActive(true);
                    break;
                }
                else if (toolManager.GetCurrentStep() < steps[i])
                {
                    controledIndex = i;
                    kControledObjs[controledIndex].SetActive(true);
                    break;
                }
            }
        }
        else
        {
            //TODO 如果kControledObjs有两个，当操作到第二个的时候隐藏的是第一个
            //解决办法：将kControledObjs[controledIndex]改为kControledObjs[toolManager.GetCurrentStep()]
            Animator[] anims = kControledObjs[controledIndex].GetComponentsInChildren<Animator>();
            for (int i = 0; i < anims.Length; i++)
            {
                anims[i].enabled = false;
            }
            kControledObjs[controledIndex].SetActive(false);
        }

        //if (isOn)
        //{
        //    if (!kControledObj.activeSelf)
        //    {
        //        toolManager.kCursorCur = kCursor;
        //        kControledObj.SetActive(true);
        //    }
        //}
        //else
        //{
        //    Animator[] anims = kControledObj.GetComponentsInChildren<Animator>();
        //    for (int i = 0; i < anims.Length; i++)
        //    {
        //        anims[i].enabled = false;
        //    }
        //    kControledObj.SetActive(false);
        //}
    }

}

