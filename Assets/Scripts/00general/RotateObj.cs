using UnityEngine;
using System.Collections;

public class RotateObj : MonoBehaviour
{
    float x, y;
    public float rotateSpeed = 30f;
    public Vector3 center = new Vector3(0, 1.5f, 0);
    public float yMin = -15f;
    public float yMax = 30f;
    public float scrollSpeed = 12f;

    public float distance = 4;
    public float distanceMin = 1f;
    public float distanceMax = 5f;
    Vector3 direction = Vector3.forward;

    Transform mTrans;
    // Use this for initialization
    void Start()
    {
        mTrans = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;

            y = Mathf.Clamp(y, yMin, yMax);
            Quaternion q = Quaternion.Euler(y, x, 0);
            direction = q * Vector3.forward;
        }


        //键盘沿Z轴缩放
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        if (scrollValue != 0)
            distance -= scrollValue * scrollSpeed;
        //限制距离
        distance = Mathf.Clamp(distance, distanceMin, distanceMax);
        mTrans.position = center - direction * distance;
        mTrans.LookAt(center);
    }
}