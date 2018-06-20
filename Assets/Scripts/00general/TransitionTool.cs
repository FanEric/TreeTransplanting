using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class TransitionTool : MonoBehaviour {
    public delegate void MaskDelegate();
    public event MaskDelegate maskingEvent;
    public event MaskDelegate maskingOverEvent;

    public static TransitionTool Instance;
    private Image kMask;

    void Awake()
    {
        Instance = this;
    }
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        kMask = GetComponent<Image>();
    }
	
    public void BeginTransition()
    {
        gameObject.SetActive(true);
        kMask.DOFade(1f, 1.5f).OnComplete(FadeOut);
    }

    void FadeOut()
    {
        //Debug.Log("FadeOut");
        if (maskingEvent != null)
            maskingEvent();

        kMask.DOFade(0f, 1f).OnComplete(OnMaskOver);
    }

    void OnMaskOver()
    {
        gameObject.SetActive(false);
        if (maskingOverEvent != null)
            maskingOverEvent();
    }

}

