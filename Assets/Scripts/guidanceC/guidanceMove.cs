using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guidanceMove : MonoBehaviour
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
    public int longTouch = 0;
    void FixedUpdate()
    {
        Scene scene = SceneManager.GetActiveScene();
        //Z轴位置稳定
        if (scene.name == "Chapter1guidance")
        {
            Debug.Log("ininini");
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        }
        else
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0);

        }
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


            //长按判断 触摸持续时间 触摸位置不变 且触摸在物体上
            if (touch.phase == TouchPhase.Began)
            {
                newTouchTime = Time.time;
            }
            else if (touch.phase == TouchPhase.Stationary && (Mathf.Abs(Input.GetTouch(0).deltaPosition.x) < 5))
            {
                if (Time.time - newTouchTime > 0.6f)
                {
                    longTouch = 1;
                }
                else
                {
                    longTouch = 0;
                }

            }
            if (longTouch == 1 && Physics.Raycast(ray, out hit)&&myTag=="zuodou")
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (GetComponent<FixedJoint>())
                    {
                        //触摸位置与上次触摸位置之间的差异
                        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                        hit.transform.parent.Translate(touchDeltaPosition.x * Time.deltaTime * 2, touchDeltaPosition.y * Time.deltaTime * 2, 0, Space.World);
                    }
                    else
                    {

                        //触摸位置与上次触摸位置之间的差异
                        Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

                        if (scene.name == "Chapter1guidance")
                        {
                            hit.transform.Translate(touchDeltaPosition.x * Time.deltaTime * 10, touchDeltaPosition.y * Time.deltaTime * 10, 0, Space.World);
                        }
                        else
                        {
                            hit.transform.Translate(touchDeltaPosition.x * Time.deltaTime * 2, touchDeltaPosition.y * Time.deltaTime * 2, 0, Space.World);
                        }
                    }

                }

            }
            //对被射击到物体进行旋转
            

            }

        }


    }


