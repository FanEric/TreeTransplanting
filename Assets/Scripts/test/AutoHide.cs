using UnityEngine;
using System.Collections;

public class AutoHide : MonoBehaviour {

    public float showTime = 3f;

    private float elapsedTime = 0f;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.activeSelf)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= showTime)
            {
                gameObject.SetActive(false);
                elapsedTime = 0f;
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        elapsedTime = 0f;
    }

}

