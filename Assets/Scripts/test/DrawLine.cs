using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

    /// <summary>  
    /// 鼠标画图功能  
    /// </summary>  
    private GameObject clone;
    private LineRenderer line;
    private int i;
    public GameObject tf;

    private RaycastHit hit;

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clone = (GameObject)Instantiate(tf, transform.position, transform.rotation);//克隆一个带有LineRender的物体  
            line = clone.GetComponent<LineRenderer>();//获得该物体上的LineRender组件  
            line.SetColors(Color.red, Color.red);//设置颜色  
            line.SetWidth(0.01f, 0.01f);//设置宽度  
            i = 0;
        }
        
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10))
            {
                i++;
                line.SetVertexCount(i);//设置顶点数  
                line.SetPosition(i - 1, new Vector3(hit.point.x, hit.point.y, hit.point.z));//设置顶点位置  
            }
        }
    }
}
