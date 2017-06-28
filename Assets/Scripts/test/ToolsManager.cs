using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ToolsManager : GameControl
{
    public GraphicRaycaster graphicRaycaster;
    public EventSystem eventSystem;
    public Transform toolsContainer;

    public Animator kAnimBJ;
    public Animator kAnimMSHQ;
    public Animator kAnimMSZS;

    public AudioManager audioManager;
    public ScoreManager scoreManager;

    public Texture2D kCursorMS1;
    public Texture2D kCursorMS2;
    public Texture2D kCursorST;
    public Texture2D kCursorJD;
    public Texture2D kCursorTQ;

    public Collider kColliderSZ;
    public Collider kColliderXJSZ;

    [HideInInspector]
    public Texture2D kCursorCur = null;
    public GameObject kYQT;

    //private Transform _selectedTool;
	private bool changeCursor;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = new Vector2(32, 32);

    private RaycastHit hit;
    private GameObject hoverObj;

    private int step = 1;
    Toggle[] btnTools;
    public override void GameInit()
    {
        btnTools = toolsContainer.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < btnTools.Length; i++)
        {
            btnTools[i].enabled = false;
        }
    }

    public override void GameBegin()
    {
        for (int i = 0; i < btnTools.Length; i++)
        {
            btnTools[i].enabled = true;
        }
        //Debug.Log("GameBegin");
        audioManager.PlayAudio(304, "对已选好的树木,在树干阴面进行标注（满足对蔽阴和光照的要求）");
    }

    void Update()
	{
        SetCursor();

        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit, 10))
        //{
        //    hoverObj = hit.collider.gameObject;
        //    hoverObj.GetComponent<MeshRenderer>().enabled = true;
        //    if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        //    {
        //        StartCoroutine(hoverObj.GetComponent<BaseStepCheck>().DoStep());
        //    }
        //}
        //else
        //{
        //    if (hoverObj != null)
        //    {
        //        hoverObj.GetComponent<MeshRenderer>().enabled = false;
        //        hoverObj = null;
        //    }
        //}
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

    public void OnGrabTool(string toolName)
    {
        changeCursor = true;
        toolName = toolName.Substring(7);
        HideOtherTools();

        switch (toolName)
        {
            case "ShuaZi":
                kYQT.SetActive(true);
                kCursorCur = kCursorMS1;
                break;
            case "ShuiTong":
                kCursorCur = kCursorST;
                kColliderSZ.gameObject.SetActive(true);
                break;
            case "JianDao":
                kCursorCur = kCursorJD;
                kColliderXJSZ.gameObject.SetActive(true);
                break;
            case "TieQiao":
                kCursorCur = kCursorTQ;

                break;
            default:
                break;
        }
    }

    void HideOtherTools()
    {
        kYQT.SetActive(false);
        kColliderSZ.gameObject.SetActive(false);
        kColliderXJSZ.gameObject.SetActive(false);

    }

    void SetCursor()
    {
        ////加上这段以后，当鼠标悬浮在3D物体上的时候也会变回原来的样子
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
        //    return;
        //}

        //PointerEventData eventData = new PointerEventData(eventSystem);
        //List<GameObject> hoveredObjs =  eventData.hovered;
        //Debug.Log("hoveredObjs.Count: " + hoveredObjs.Count);
        //for (int i = 0; i < hoveredObjs.Count; i++)
        //{
        //    if (hoveredObjs[i].layer == LayerMask.NameToLayer("UI"))
        //    {
        //        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        //        return;
        //    }
        //}
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

    public void OnReleaseTool()
    {
        
    }

//    void Update()
//    {
//        if (_selectedTool != null)
//        {
//			_selectedTool.position = new Vector3(Input.mousePosition.x - Screen.width / 2f, Input.mousePosition.y - Screen.height / 2);
////            _selectedTool.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
//        }
//    }

}

