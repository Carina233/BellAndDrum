using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class choosePartObj : MonoBehaviour
{
    // Start is called before the first frame update
    string myTag = null;
    string myName = null;
    void Start()
    {
        GameObject nextBtn = GameObject.Find("nextBtn");
        nextBtn.GetComponent<Button>().interactable = false;
        GameObject Finish = GameObject.Find("Finish");
        Finish.GetComponent<Button>().interactable = false;
    }
    // Update is called once per frame
    
     //持有当前外发光需要的组件
     private HighlightableObject m_ho;

    void Awake()
    {
        //初始化组件
        m_ho = GetComponent<HighlightableObject>();
    }


    void HighLightFunction()
    {
        //循环往复外发光开启（参数为：颜色1，颜色2，切换时间）
        //m_ho.FlashingOn(Color.green, Color.blue, 1f);
        m_ho.FlashingOn(Color.green, Color.green, 1f);

        //关闭循环往复外发光
        m_ho.FlashingOff();


        //持续外发光开启（参数：颜色）
        m_ho.ConstantOn(Color.yellow);

        //关闭持续外发光
        m_ho.ConstantOff();
    }

    /// <summary>
    /// 鼠标指向模型时触发4     /// </summary>
    private void OnMouseEnter()
    {
        //开启外发光
        m_ho.FlashingOn(new Color32(18,183,245,255), new Color32(0, 122, 204, 255), 1f);
        GameObject Finish = GameObject.Find("Finish");
        Finish.GetComponent<Button>().interactable = true;
        Finish.GetComponent<Image>().color = new Color(1, 1, 0, 1);

        Text myText3;
        myText3 = GameObject.Find("Text3").GetComponent<Text>();
        myText3.text = "请点击右侧绿色的完成键！";


    }

    /// <summary>2     /// 鼠标离开模型时触发
    /// </summary>
    private void OnMouseExit()
    {
        //关闭外发光
        m_ho.FlashingOff();
        //GameObject Finish = GameObject.Find("Finish");
        //Finish.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        //Finish.GetComponent<Button>().interactable = false;
    }

    void FixedUpdate()
    {
        
        
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

                    GameObject nextBtn = GameObject.Find("nextBtn");
                    nextBtn.GetComponent<partIntroduction>().chooseTag = myTag;
                    GameObject Finish = GameObject.Find("Finish");
                    Finish.GetComponent<partIntroduction>().chooseTag = myTag;
                    

                }
                else
                {
                    myTag = hit.transform.tag;
                    Debug.Log(hit.transform.tag);
                    GameObject nextBtn = GameObject.Find("nextBtn");
                    nextBtn.GetComponent<partIntroduction>().chooseTag = myTag;
                    GameObject Finish = GameObject.Find("Finish");
                    Finish.GetComponent<partIntroduction>().chooseTag = myTag;

                    myName = hit.transform.name;
                    nextBtn.GetComponent<partIntroduction>().chooseName = myName;
                    Finish.GetComponent<partIntroduction>().chooseName = myName;

                    
                }


            }



            //对被射击到物体进行旋转
            if (myTag == transform.tag)
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
