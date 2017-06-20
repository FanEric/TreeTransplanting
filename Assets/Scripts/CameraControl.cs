using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

/// <summary>
/// Author: 范高征
/// Data: 2015-08-07
/// Desc:通过手势操作实现主摄像机的控制
/// </summary>
public class CameraControl : MonoBehaviour
{
    public Transform kTarget;
    public float initDistance = 5.7f;
    public float distanceMax = 20f;
    public float distanceMin = 3f;
    public float desiredDistance;
    public float angleMax = 30;
    public float angleMin = -30;
    public float scrollSpeed = 12f;
    public float rotateSpeed = 4f;
    public float panSpeed = 5f;
    public float mouseX = 0f;
    public float mouseY = 60f;
    private float lastX;
    private float lastY;

    private float DPI = 0;
    private float currentDistance = 0f;
    private Vector3 _kPosition;
    private float mouseMoveX = 0f;
    private float mouseMoveY = 0f;
    private Vector3 _tInitPos;
    private Vector3 velocity = Vector3.zero;
    private float velocityZ = 0f;
    private float delayZ = 0.3f;
    private Transform hitTrans;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;


    public static bool isOnUI = false; //触控是否在UI上
    public EventSystem eventSystem;
    public GraphicRaycaster graphicRaycaster;
    /// <summary>
    /// 实现距离拉近拉远的平滑效果，上一次相机停留点
    /// </summary>
    private float lastDistance;
    /// <summary>
    /// 实现距离拉近拉远的平滑效果，每一帧相机要移动到的位置
    /// </summary>
    private float perDistance;
    /// <summary>
    /// 用来记录缩放趋势
    /// </summary>
    private Vector2 endone;
    private Vector2 endtwo;

    /// <summary>
    /// 相机是否获取居中规定的角度，是为true，当鼠标旋转则不获取该角度
    /// </summary>
    private bool hasRotate = false;
    /// <summary>
    /// 是否是触屏
    /// </summary>
    private bool isTouch = false;
    /// <summary>
    /// 用来记录双击的第一次点击物体是否为空
    /// </summary>
    private GameObject clickObj;

    /// <summary>
    /// 单击时选中的物体
    /// </summary>
    private GameObject singleSelectedObj;

    /// <summary>
    /// 双击计时器
    /// </summary>
    private float timer = 0.28f;

    private RaycastHit hit;
    /// <summary>
    /// 摄像机参考点要移动到的位置
    /// </summary>
    [HideInInspector]
    public Vector3 hitPos;
    /// <summary>
    /// 是否要居中显示
    /// </summary>
    private bool _isFocus = false;


    /// <summary>
    /// 物体居中的时候相机停留的位置
    /// </summary>
    private Transform CenterPos;
    Transform mTrans;


    void Awake()
    {
        hitPos = Vector3.zero;
        mTrans = this.transform;
        desiredDistance = currentDistance = initDistance;
        lastDistance = distanceMax;
    }

    // Use this for initialization
    void Start()
    {
        DPI = Screen.height / 1080f;
        clickObj = null;
        lastX = mouseX;
        lastY = mouseY;

        _tInitPos = kTarget.position;
        initDistance = Mathf.Clamp(initDistance, 1.25f, distanceMax);
    }

    // Update is called once per frame
    public void Update()
    {
        if (_isFocus)
        {
            kTarget.position = Vector3.SmoothDamp(kTarget.position, hitPos, ref velocity, delayZ - 0.1f);
            Vector3 distancPos = CenterPos.position - hitPos;
            float disMag = distancPos.magnitude;
            desiredDistance = disMag;

            if (Vector3.Distance(kTarget.position, hitPos) < 0.0005f)
            {
                _isFocus = false;
            }

        }

        if (clickObj != null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0.28f;
                clickObj = null;
            }
        }
    	GetInputMessage();
    	PostionUpdate();
    }

    /// <summary>
    /// 获取控制信息
    /// </summary>
    public void GetInputMessage()
    {
//        CheckMouseOnUI();
        if (isOnUI) return;

        Vector3 mPos = Input.mousePosition;

        #region 点击物体
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (clickObj != null && hit.collider.gameObject == clickObj)
                    {
                        //_isFocus = true;
                        //hasRotate = true;
                        Application.LoadLevel(0);
                    }
                    else //单击
                    {
                        clickObj = hit.collider.gameObject;
                        
                    }
                }
            }
        }
        #endregion


        #region 触屏操作
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                mouseX += Input.GetTouch(0).deltaPosition.x * rotateSpeed * DPI * 0.3f;
                mouseY -= Input.GetTouch(0).deltaPosition.y * rotateSpeed * DPI * 0.3f;
            }

            //触屏缩放
            if (Input.touchCount == 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
                {
                    Vector2 startone = Input.GetTouch(0).position;
                    Vector2 starttwo = Input.GetTouch(1).position;
                    if (isEnlarge(startone, starttwo, endone, endtwo))
                    {
                        if (desiredDistance < distanceMax)
                            desiredDistance += DPI * 1f;
                    }
                    else
                    {
                        if (desiredDistance > 5f)
                            desiredDistance -= DPI * 1f;
                    }
                    endone = startone;
                    endtwo = starttwo;
                }
            }

            //触屏实现拖拽
            if (Input.touchCount == 3)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved
                    && Input.GetTouch(2).phase == TouchPhase.Moved)
                {
                    kTarget.Translate(mTrans.right * -Input.GetTouch(0).deltaPosition.x * Time.deltaTime * panSpeed * GetDistanceRate());
                    kTarget.Translate(mTrans.up * -Input.GetTouch(0).deltaPosition.y * Time.deltaTime * panSpeed * GetDistanceRate());
                }
            }

            isTouch = true;
        }
        else
        {
            isTouch = false;
        }
        #endregion


        #region 键盘操作，旋转和拖拽
        if (Input.GetMouseButton(0) && !isTouch)
        {
            if (transform.gameObject.tag == "MainCamera")
            {
                mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
                mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;

                if (mouseX != lastX || mouseY != lastY)
                {
                    hasRotate = false;
                }

                lastX = mouseX;
                lastY = mouseY;
            }
        }

        if (Input.GetMouseButton(1) && !isTouch)
        {
            _isFocus = false;
            //kTarget.Translate(mTrans.right * -Input.GetAxis("Mouse X") * Time.deltaTime * panSpeed * GetDistanceRate(), Space.World);
            //         kTarget.Translate(mTrans.up * -Input.GetAxis("Mouse Y") * Time.deltaTime * panSpeed * GetDistanceRate(), Space.World);
            kTarget.Translate(Vector3.right * -Input.GetAxis("Mouse X") * Time.deltaTime * panSpeed * GetDistanceRate(), Space.World);
            kTarget.Translate(Vector3.forward * -Input.GetAxis("Mouse Y") * Time.deltaTime * panSpeed * GetDistanceRate(), Space.World);
        }
        #endregion

        mouseY = ClampAngle(mouseY, angleMin, angleMax);

        //键盘沿Z轴缩放
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        if (scrollValue != 0)
            desiredDistance -= scrollValue * scrollSpeed * GetDistanceRate();
        //限制距离
        desiredDistance = Mathf.Clamp(desiredDistance, distanceMin, distanceMax);
    }

    float GetDistanceRate()
    {
        return desiredDistance / distanceMax;
    }

    /// <summary>
    /// 通过输入的控制信息进行摄像机的操作
    /// </summary>
    private void PostionUpdate()
    {
        currentRotation = mTrans.rotation;
        if (!hasRotate)
        {
            desiredRotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            desiredRotation = CenterPos.rotation;
            mouseY = transform.eulerAngles.x;           //用来初始化居中之后鼠标旋转角度
            mouseX = transform.eulerAngles.y;
        }

        Quaternion rotation = Quaternion.Slerp(currentRotation, desiredRotation, Time.deltaTime * 2f);

        perDistance = Mathf.SmoothDamp(lastDistance, desiredDistance, ref velocityZ, delayZ);
        lastDistance = perDistance;

        Vector3 position = rotation * new Vector3(0f, 0f, -perDistance) + kTarget.position;
        mTrans.rotation = rotation;
        mTrans.position = position;
    }

    /// <summary>
    /// 摄像机角度限制
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

    /// <summary>
    /// 检测鼠标是否在UI上
    /// </summary>
    void CheckMouseOnUI()
    {
        PointerEventData eventData = new PointerEventData(eventSystem);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;
        List<RaycastResult> list = new List<RaycastResult>();
        graphicRaycaster.Raycast(eventData, list);
        isOnUI = list.Count > 0 ? true : false;
    }

    /// <summary>
    /// 放大缩小手势判断
    /// </summary>
    /// <param name="oP1"></param>
    /// <param name="oP2"></param>
    /// <param name="nP1"></param>
    /// <param name="nP2"></param>
    /// <returns></returns>
    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        float length1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float length2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));

        if (length1 < length2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
