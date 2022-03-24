using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class guidanceRightOrNot : MonoBehaviour
{
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void showAlertWin()
    {
        //var myWin = GameObject.FindWithTag("alertWin");
        //myWin.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
    }
    public void closeAlertWin()
    {
        //var myWin = GameObject.FindWithTag("alertWin");
        //myWin.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void nextStep()
    {
        var text1 = GameObject.FindWithTag("text1");
        text1.gameObject.SetActive(false);
        var text2 = GameObject.FindWithTag("text2");
        text2.gameObject.SetActive(false);
        var text3Parent = GameObject.FindWithTag("Label");

        var text3 = text3Parent.transform.Find("Text3").gameObject;
        text3.gameObject.SetActive(true);

        var rotationJS = GameObject.Find("Mesh1").GetComponent<guidanceRotation>();
        rotationJS.enabled = false;
        rotationJS.gameObject.AddComponent<touchObj>();

        var moveJS=GameObject.Find("Mesh2").GetComponent<guidanceMove>();
        moveJS.enabled = false;
        moveJS.gameObject.AddComponent<touchObj>();

        var groupTouch = GameObject.FindWithTag("group1");
        groupTouch.gameObject.AddComponent<touchObj>();

        this.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tringggggggggg");
        Time.timeScale = 0;
        GameObject group1 = GameObject.FindWithTag("group1");
        foreach (Transform child in group1.transform)
        {
            if (child.gameObject.name == other.transform.gameObject.name || child.gameObject.name == transform.gameObject.name)
            {
                Debug.Log("ddd");
                child.gameObject.SetActive(true);
            }

            Debug.Log(child.gameObject.name);
        }

        if (other.transform.gameObject.name != "group1")
        {
            Debug.Log("ttt");
            GameObject myGlobal = GameObject.Find("Global");
            myGlobal.GetComponent<guidanceGlobal>().myFinish=1;

            Destroy(other.transform.gameObject);
            Destroy(transform.gameObject);
            
        }

        Time.timeScale = 1;
    }
   
    public void guidanceReset()
    {
        Scene scene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(scene.name);
        
    }
    //public void guidanceDrawing()
    //{

    //}
    public void guidanceFinish()
    {
        this.gameObject.SetActive(true);
        Text myText;
        myText = GameObject.Find("alertText").GetComponent<Text>();
        GameObject myGlobal = GameObject.Find("Global");
        var f=myGlobal.GetComponent<guidanceGlobal>().myFinish;
        if (f == 0)
        {
            myText.text = "未完成";
        }
        else
        {
            myText.text = "恭喜完成";
        }


    }
    public void guidanceTip()
    {
        this.gameObject.SetActive(true);
        Text myText;
        myText = GameObject.Find("alertText").GetComponent<Text>();
        
        myText.text = "这是提示界面~";
        
    }
}
