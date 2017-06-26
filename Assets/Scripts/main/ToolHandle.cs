using UnityEngine;
using UnityEngine.UI;

public class ToolHandle : MonoBehaviour {
    public Texture2D kCursor;
    public Texture2D kCursorSpare;
    public GameObject kControledObj;

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
            if (!kControledObj.activeSelf)
            {
                toolManager.kCursorCur = kCursor;
                kControledObj.SetActive(true);
            }
        }
        else
        {
            kControledObj.SetActive(false);
            //if (toolManager.kCursorCur == kCursor)
            //{
            //    kControledObj.SetActive(false);
            //}
            //if (kCursorSpare != null && toolManager.kCursorCur == kCursorSpare)
            //{
            //    kControledObj.SetActive(false);
            //}
        }
    }

}

