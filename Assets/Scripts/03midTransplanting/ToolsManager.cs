using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/// <summary>
/// 移植过程管理类
/// </summary>
public class ToolsManager : MonoBehaviour
{
    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;

    public QuestionModule questionModule;

    public AutoHide kMotion;
    public Transform toolsContainer;

    public AudioManager audioManager;
    public ScoreManager scoreManager;

    [HideInInspector]
    public Texture2D kCursorCur = null;

    public GameObject kRawImage;
    public GameObject kBeginBefore;
    public GameObject kBeginAfter;
    public GameObject kToolsContainerBefore;
    public GameObject kToolsContainerAfter;

    private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = new Vector2(32, 32);

    public int step = 0;
    Button[] btnTools;

    private int cQuestionId = 305;
    //是否正在播放动画，如果是，则不能选择别的工具
    private bool isAnimating = false;

    void Start()
    {
        kBeginBefore.GetComponent<Button>().onClick.AddListener(OnBeginBefore);
        kBeginAfter.GetComponent<Button>().onClick.AddListener(OnBeginAfter);
        InitQuestionModule();

        btnTools = toolsContainer.GetComponentsInChildren<Button>();
        SetAnimating(true);
    }
    void OnBeginBefore()
    {
        kRawImage.SetActive(false);
        kBeginBefore.SetActive(false);
        SetAnimating(false);
        //Debug.Log("GameBegin");
        audioManager.PlayAudio(3001, "对已选好的树木,在树干阴面进行标注（满足对蔽阴和光照的要求）");
    }

    public void ShowBeginAfter()
    {
        kRawImage.SetActive(true);
        kBeginAfter.SetActive(true);

        kToolsContainerBefore.SetActive(false);
        kToolsContainerAfter.SetActive(true);
    }

    void OnBeginAfter()
    {
        kRawImage.SetActive(false);
        kBeginAfter.SetActive(false);
        SetAnimating(false);
        //Debug.Log("GameBegin");
        audioManager.PlayAudio(3019, "为防止水分蒸腾过大，需用草绳包裹从根部至离地2m左右的树干（对草绳浇水保持韧性，草绳间不留空隙）");
    }

    void EnableTools(bool isEnable)
    {
        for (int i = 0; i < btnTools.Length; i++)
        {
            btnTools[i].enabled = isEnable;
        }
    }

    void InitQuestionModule()
    {
        //测试用，发布的时候可注释掉
        Utils.ParseQuestions();
        questionModule.Init();
        questionModule.questionOverEvent += DoQuestionOver;
        questionModule.Show(false);
    }

    void OnDestroy()
    {
        questionModule.questionOverEvent -= DoQuestionOver;
    }

    public void ShowQuestion()
    {
        questionModule.Show(true);
        questionModule.RequestQuestion(cQuestionId);
    }

    private void DoQuestionOver()
    {
        //实在没有更好的处理办法了
        if (cQuestionId == 305)
        {
            cQuestionId = 3071;
            questionModule.Show(false);
            FindObjectOfType<JC2Check>().GotoNextStep();
        }
        else if (cQuestionId == 3071)
        {
            cQuestionId = 3072;
            ShowQuestion();
        }
        else if (cQuestionId == 3072)
        {
            cQuestionId = 309;
            questionModule.Show(false);
            FindObjectOfType<TQWaGouCheck>().GotoNextStep();
        }
        else if (cQuestionId == 309)
        {
            cQuestionId = 315;
            questionModule.Show(false);
            FindObjectOfType<TQShouDiCheck>().GotoNextStep();
        }
        else if (cQuestionId == 315)
        {
            cQuestionId = 0;
            questionModule.Show(false);
            TransitionTool.Instance.BeginTransition();
        }
    }

    public bool CheckStep(int s)
    {
        Debug.Log("s:step--> " + s + "--" + step);
        if (s == step)
        {
            //step++;
            return true;
        }
        else
        {
            int score = 1;
            if (step == 0 || step == 1 || step == 5 || step == 7 || step == 8 || step == 9 || step == 17 || step == 19)
                score = 2;
            scoreManager.UpdateScore(score);
            Debug.Log("wrong");
           
            return false;
        }
    }

    public int GetCurrentStep()
    {
        return step;
    }

    public void SetAnimating(bool isAnim)
    {
        isAnimating = isAnim;
    }

    void Update()
	{
        //发布的时候一定要打开！！！
        EnableTools(!isAnimating);
        SetCursor();
    }

    void SetCursor()
    {
        if (CheckGuiRaycastObjects())
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            return;
        }
        Cursor.SetCursor(kCursorCur, hotSpot, cursorMode);
    }

    bool CheckGuiRaycastObjects()
    {
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;

        List<RaycastResult> list = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, list);
        //Debug.Log(list.Count);
        return list.Count > 0;
    }

}

