using UnityEngine;  
using System.Collections;

public class touchCamera : MonoBehaviour
{

    //private float mouseX;
    //private float mouseY;

    private Touch oldTouch1;
    private Touch oldTouch2;
    private Touch newTouch1;
    private Touch newTouch2;
    string myTag = null;
    //int change = 0;
    void FixedUpdate()
    {

        if(Input.touchCount<=0)
        {
            return;
        }
        //选择物体进行下一步操作
        if(Input.touchCount==1)
        {
            Touch touch = Input.GetTouch(0);
            //建立触摸屏幕点发射的射线
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //得到射线击到物体名称
            if (Physics.Raycast(ray, out hit))
            {
                
                myTag = hit.transform.tag;
                //Debug.Log(hit.transform.tag);
                //将摄像机对准物体
                //transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, transform.position.z);
            }
           
            
        }
        //对物体视角拉近/拉远
        if(Input.touchCount>1)
        {

            newTouch1 = Input.GetTouch(0);
            newTouch2 = Input.GetTouch(1);
            if(newTouch2.phase==TouchPhase.Began)
            {
                oldTouch1 = newTouch1;
                oldTouch2 = newTouch2;
                return;
            }
            float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
            float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
            //计算新旧触摸差值
            float offset = newDistance - oldDistance;
            if(offset<0)
            {
                if (Camera.main.fieldOfView <= 60)
                    this.GetComponent<Camera>().fieldOfView++;
                // 摄像机的正交投影
                if (Camera.main.orthographicSize <= 10)
                    this.GetComponent<Camera>().orthographicSize += 0.5f;
            }
            else if(offset>0)
            {
                if (this.GetComponent<Camera>().fieldOfView > 30)
                    this.GetComponent<Camera>().fieldOfView--;
                if (this.GetComponent<Camera>().orthographicSize >= 5)
                    this.GetComponent<Camera>().orthographicSize -= 0.5f;
            }
        }
    }
}