using UnityEngine;
using System.Collections;

public class TestCursor : MonoBehaviour {
    public Texture2D kCursor;
    public Texture2D kCursor2;

    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = new Vector2(32, 32);

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(kCursor, hotSpot, cursorMode);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(kCursor2, hotSpot, cursorMode);
        }
    }
}

