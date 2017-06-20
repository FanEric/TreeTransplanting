using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    MeshRenderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<MeshRenderer>();
    }
	
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        if (!rend.enabled)
            rend.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        if (rend.enabled)
            rend.enabled = false;
    }

}
