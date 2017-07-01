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
            Animator[] anims = kControledObj.GetComponentsInChildren<Animator>();
            for (int i = 0; i < anims.Length; i++)
            {
                anims[i].enabled = false;
            }
            kControledObj.SetActive(false);
        }
    }

}

