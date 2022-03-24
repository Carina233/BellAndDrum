using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CSS : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private Text text;
    private string defaultStr;
    private string hightlightStr;
    // Start is called before the first frame update
    void Start()
    {
        //屏幕背景适配
        GameObject MyCanvas = GameObject.Find("Canvas");
        float Cwidth = MyCanvas.GetComponent<RectTransform>().rect.width;
        float Cheight = MyCanvas.GetComponent<RectTransform>().rect.height;
        GameObject MyImage = GameObject.Find("Image");
        float LastImageWidth = MyImage.transform.GetComponent<RectTransform>().rect.width;
        float LastImageHeight = MyImage.transform.GetComponent<RectTransform>().rect.height;
        float deltaWidth = Cwidth / LastImageWidth;
        float deltaHeight = Cheight / LastImageHeight;


        //GameObject MyQuit = GameObject.Find("Quit");
        //float MyQuitWidth = MyQuit.GetComponent<RectTransform>().rect.width;
        //float MyQuitHeight = MyQuit.GetComponent<RectTransform>().rect.height;
        //MyQuit.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(MyQuitWidth * deltaWidth, MyQuitHeight * deltaHeight);

        MyImage.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Cwidth, Cheight);
        
        //放缩小图标按钮
        // GameObject FixedFunction = GameObject.Find("fixedFunction");
        // FixedFunction.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Cwidth, Cheight);
        //foreach(Transform child in FixedFunction.transform)
        //{
        //        float ChildWidth = child.GetComponent<RectTransform>().rect.width;
        //        float ChildHeight = child.GetComponent<RectTransform>().rect.height;
        //        child.GetComponent<RectTransform>().sizeDelta = new Vector2(ChildWidth * deltaWidth, ChildHeight * deltaHeight);
             
        //}
       
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Btn()
    {
        //text = this.GetComponentInChildren<Text>();
        //text.color = new Color(0, 0, 168);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (this.name=="onStartBtn")
        {
            Debug.Log("aaa");
            text = this.GetComponentInChildren<Text>();
            text.color = new Color32(0, 100, 200,255);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (this.name == "onStartBtn")
        {
            Debug.Log("bbb");
            text = this.GetComponentInChildren<Text>();
            text.color = new Color32(56, 56, 56,255);
        }
    }
}
