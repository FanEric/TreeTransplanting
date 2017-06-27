using UnityEngine;
using System.Collections;

public class BaseStepDragCheck : MonoBehaviour {

    public float totalDistance = 10f;
    RaycastHit hit;

    float lastMousePosX = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5))
            {
                Transform hitObj = hit.collider.transform;
                if (hitObj == transform)
                {
                    Debug.Log("111");
                    if (lastMousePosX != 0)
                    {
                        float rate = Input.mousePosition.x - lastMousePosX;
                        transform.Translate(Vector3.forward * rate / 100f, Space.Self);
                    }
                    lastMousePosX = Input.mousePosition.x;
                }
            }


           
        }
    }
}

