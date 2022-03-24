using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tipsImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sureEnter()
    {
        //GameObject alertWin = GameObject.Find("alertWin");
        //alertWin.SetActive(true);
        this.gameObject.SetActive(true);
        Text alertText;
        alertText = GameObject.Find("alertText").GetComponent<Text>();
        alertText.text = "确定查看提示？";

        foreach(Transform child in this.transform)
        {
            if(child.name=="sureButton")
            {
                child.gameObject.SetActive(true);
            }
        }
        //GameObject sureBtn = GameObject.Find("sureButton");
        //sureBtn.GetComponent<Button>().interactable = true;
    }
    public void showImage()
    {
        GameObject sureBtn = GameObject.Find("sureButton");
        sureBtn.GetComponent<Button>().interactable = false;
        this.gameObject.SetActive(true);
        //GameObject sureButton = GameObject.Find("sureButton");
        //sureButton.SetActive(false);

        Text alertText;
        alertText = GameObject.Find("alertText").GetComponent<Text>();
        alertText.text = " ";
    }
    public void closeTip()
    {
        this.gameObject.SetActive(false);
       
    }
    public void hideImage()
    {
        this.gameObject.SetActive(false);
    }
}