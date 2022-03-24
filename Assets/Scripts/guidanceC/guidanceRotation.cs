using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guidanceRotation : MonoBehaviour
{
    private Touch oldTouch1;//上次触摸点1（手指1）
    private Touch oldTouch2;//上次触摸点2（手指2）
    private float newTouchTime;
    //private float touchTime = 1f;
    string myTag = null;


    // Start is called before the first frame update
    void Start()
    {

        // Update is called once per frame
    }
    //public int longTouch = 0;
    void FixedUpdate()
    {
        Scene scene = SceneManager.GetActiveScene();
        //Z轴位置稳定
        
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        
        
        //没有触摸
        if (Input.touchCount <= 0)
        {
            return;

        }
        //单点触摸
        if (Input.touchCount == 1)
        {


            //float speed = 0.1f;
            Touch touch = Input.GetTouch(0);

            //建立触摸屏幕点发射的射线
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //得到射线击到物体名称
            if (Physics.Raycast(ray, out hit))
            {
                //gameObject.AddComponent<Highlight>();
                //gameObject.AddComponent<HighlightableObject>();
                if (GetComponent<FixedJoint>())
                {

                    //Debug.Log(hit.transform.parent.tag);
                    myTag = hit.transform.parent.tag;
                }
                else
                {
                    myTag = hit.transform.tag;
                    Debug.Log(hit.transform.tag);
                }


            }


            

            //对被射击到物体进行旋转
            if (myTag == transform.tag&&myTag=="zhengxinguagong")
            {
                //添加边缘高亮脚本
                //gameObject.AddComponent<Highlight>();
                //gameObject.AddComponent<HighlightableObject>();

                if (GetComponent<FixedJoint>())
                {
                    Vector2 deltaPos = touch.deltaPosition;
                    //调节水平与竖直敏感度 尽量一次只更改水平或仅更改竖直
                    //if (Mathf.Abs(deltaPos.x) > Mathf.Abs(deltaPos.y * 6))
                    //{
                    //调节手指控制灵敏度
                    Debug.Log(transform.parent.tag);
                    transform.parent.Rotate(Vector3.down * deltaPos.x / 2, Space.World);//左右 
                                                                                        //}
                                                                                        //else if (Mathf.Abs(deltaPos.y) > Mathf.Abs(deltaPos.x * 2))
                                                                                        //{
                    transform.parent.Rotate(Vector3.right * deltaPos.y, Space.World);//上下
                                                                                     //}
                }
                else
                {
                    Vector2 deltaPos = touch.deltaPosition;
                    //调节水平与竖直敏感度 尽量一次只更改水平或仅更改竖直
                    //if (Mathf.Abs(deltaPos.x) > Mathf.Abs(deltaPos.y * 6))
                    //{
                    //调节手指控制灵敏度
                    transform.Rotate(Vector3.down * deltaPos.x / 2, Space.World);//左右 
                                                                                 //}
                                                                                 //else if (Mathf.Abs(deltaPos.y) > Mathf.Abs(deltaPos.x * 2))
                                                                                 //{
                    transform.Rotate(Vector3.right * deltaPos.y, Space.World);//上下
                                                                              //}
                }

            }

        }


    }

}
