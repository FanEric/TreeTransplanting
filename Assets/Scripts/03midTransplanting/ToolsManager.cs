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

    public Transform toolsContainer;

    public AudioManager audioManager;
    public ScoreManager scoreManager;

    [HideInInspector]
    public Texture2D kCursorCur = null;

    private GameObject kBeginObj;

	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = new Vector2(32, 32);

    private int step = 1;
    Button[] btnTools;

    private int cQuestionId = 305;
    //是否正在播放动画，如果是，则不能选择别的工具
    private bool isAnimating = false;

    void Start()
    {
        kBeginObj = GameObject.Find("RawImage_bgBlur");
        kBeginObj.GetComponentInChildren<Button>().onClick.AddListener(OnBegin);
        InitQuestionModule();

        btnTools = toolsContainer.GetComponentsInChildren<Button>();
        //EnableTools(false);
        SetAnimating(true);
    }
    void OnBegin()
    {
        kBeginObj.SetActive(false);
        SetAnimating(false);
        //Debug.Log("GameBegin");
        audioManager.PlayAudio(3001, "对已选好的树木,在树干阴面进行标注（满足对蔽阴和光照的要求）");
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
            GameObject.FindObjectOfType<JC2Check>().GotoNextStep();
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
            GameObject.FindObjectOfType<TQWaGouCheck>().GotoNextStep();
        }
        else if (cQuestionId == 309)
        {
            cQuestionId = 315;
            questionModule.Show(false);
            GameObject.FindObjectOfType<TQShouDiCheck>().GotoNextStep();
        }
    }

    public bool CheckStep(int s)
    {
        if (s == step)
        {
            step++;
            Debug.Log("OK");
            return true;
        }
        else
        {
            int score = 1;
            if (step == 1 || step == 2)
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

