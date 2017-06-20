using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ToolsManager : GameControl
{
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
    public Texture2D kCursorCur;
    public GameObject kYQT;

    //private Transform _selectedTool;
	private bool changeCursor;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = new Vector2(32, 32);

    private RaycastHit hit;
    private GameObject hoverObj;

    private int step = 1;
    Button[] btnTools;
    public override void GameInit()
    {
        btnTools = toolsContainer.GetComponentsInChildren<Button>();
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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10))
        {
            hoverObj = hit.collider.gameObject;
            hoverObj.GetComponent<MeshRenderer>().enabled = true;
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                hoverObj.GetComponent<BaseStepCheck>().DoStep();
            }
        }
        else
        {
            if (hoverObj != null)
            {
                hoverObj.GetComponent<MeshRenderer>().enabled = false;
                hoverObj = null;
            }
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

    void SetCursor()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
            return;
        }
        if (changeCursor)
        {
            Cursor.SetCursor(kCursorCur, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
    }

    public void OnGrabTool(string toolName)
    {
		changeCursor = true;
        toolName = toolName.Substring(7);
        HideOtherTools();

        switch (toolName) {
		    case "ShuaZi":
			    kYQT.SetActive (true);
                kCursorCur = kCursorMS1;
			    break;
            case "ShuiTong":
                kCursorCur = kCursorST;
                kColliderSZ.gameObject.SetActive(true);
                //点击水桶后让油漆桶消失
                kYQT.SetActive(false);
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

