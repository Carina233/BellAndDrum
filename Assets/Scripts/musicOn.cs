using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class musicOn : MonoBehaviour
{
    private int cardRandomNum;
    private string[] cardName = {
        "Dragon",
        "Phoenix",
        "Lion", "Lion","Lion",
        "Proteas","Proteas",
        "Pegasus",
        "SuanNi", "SuanNi",
        "XiaYu", "XiaYu",
        "Immortal",
        "XieZhi","XieZhi",
        "DouNiu","DouNiu","DouNiu","DouNiu","DouNiu",
        "Hangshi","Hangshi","Hangshi"
    };
    private string[] oldHour = {
        "子","丑","丑","寅","寅","卯","卯","辰","辰","巳","巳","午","午","未","未","申","申","酉","酉","戌","戌","亥","亥","子"
    };
    private string[] oldHour2 = {
        "夜半","鸡鸣","平旦","日出","食时","隅中","日中","日昳","哺时","日入","黄昏","人定"
    };

    private int[] nowHour =
    {
        23,0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22
    };
    private int[] nowHourLinkOld =
    {
        //0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23
         11,1,1,3,3,5,5,7,7,9,9, 11,11,1, 1, 3, 3, 5, 5, 7, 7, 9, 9, 11
    };
    // Start is called before the first frame update
    string myName = null;
    public int playerTouchTimes=0;
    public int playerTouch;
    //public AudioSource music;
    //public AudioClip on;
    void Start()
    {
        
    }

    // Update is called once per frame
    //触摸敲钟
    void Update()
    {
        //Debug.Log("00");
        if(Input.touchCount<=0)
        {
            //Debug.Log("22");
            if(playerTouch!=0)
            {
                playerTouch = 0;
                playerTouchTimes++;
                
            }
            return;
        }
        if(Input.touchCount==1)
        {
            //Debug.Log("33");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit))
            {
                myName = hit.transform.name;
                Debug.Log(myName);
            }
        }
        GameObject child = GameObject.Find(myName);
        Debug.Log(myName);

        GameObject bell = child.transform.parent.gameObject;
        
        if (bell.name=="Bell")
        {
            playerTouch++;
            AudioSource audioS = bell.GetComponent<AudioSource>();
            audioS.playOnAwake = true;
            audioS.Play();
            
            Debug.Log("onon");
            myName = null;
            //bell.GetComponent<AudioSource>().playOnAwake=true;
            
        }
    }
    
    public void clickCard()
    {

        GameObject cardRandom = GameObject.Find("cardRandom");
        Destroy(cardRandom);
        GameObject alertText = GameObject.Find("alertText");
        alertText.GetComponent<Text>().text = "成就卡已收录入我的成就，点击退出按键，开启下一关卡";
        GameObject onMusic = GameObject.Find("onMusic");

        onMusic.GetComponent<homeMusic>().chap5Pass += 1;
        onMusic.GetComponent<homeMusic>().cardName = cardName[cardRandomNum];
        //public int DouNiu = 0;
        //public int Dragon = 0;
        //public int HangShi = 0;
        //public int Immortal = 0;
        //public int Lion = 0;
        //public int Pegasus = 0;
        //public int Phoenix = 0;
        //public int Proteas = 0;
        //public int SuanNi = 0;
        //public int XiaYu = 0;
        //public int XieZhi = 0;
        switch (cardName[cardRandomNum])
        {
            case "DouNiu":
                onMusic.GetComponent<homeMusic>().DouNiu++;
                break;
            case "Dragon":
                onMusic.GetComponent<homeMusic>().Dragon++;
                break;
            case "HangShi":
                onMusic.GetComponent<homeMusic>().HangShi++;
                break;
            case "Immortal":
                onMusic.GetComponent<homeMusic>().Immortal++;
                break;
            case "Lion":
                onMusic.GetComponent<homeMusic>().Lion++;
                break;
            case "Pegasus":
                onMusic.GetComponent<homeMusic>().Pegasus++;
                break;
            case "Phoenix":
                onMusic.GetComponent<homeMusic>().Phoenix++;
                break;
            case "Proteas":
                onMusic.GetComponent<homeMusic>().Proteas++;
                break;
            case "SuanNi":
                onMusic.GetComponent<homeMusic>().SuanNi++;
                break;
            case "XiaYu":
                onMusic.GetComponent<homeMusic>().XiaYu++;
                break;
            case "XieZhi":
                onMusic.GetComponent<homeMusic>().XieZhi++;
                break;
        }

    

    }
    public void showCard()
    {
        GameObject Finish = GameObject.Find("Finish");
        Finish.GetComponent<Button>().interactable = false;
        GameObject Canvas = GameObject.Find("Canvas");
        foreach (Transform child in Canvas.transform)
        {
            if (child.name == "cardRandom")
            {
                Image img = child.gameObject.GetComponent<Image>();

                cardRandomNum = UnityEngine.Random.Range(0, 23);
                string imgName = cardName[cardRandomNum];

                string path = "Images/" + imgName;
                Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                Debug.Log(sprite);
                img.sprite = sprite;

                child.gameObject.SetActive(true);



            }
        }
    }
    public void HourTouch()
    {
        int hour = DateTime.Now.Hour;
        GameObject Canvas = GameObject.Find("Canvas");
        foreach (Transform child in Canvas.transform)
        {
            if (child.name == "alertWin")
            {
                child.gameObject.SetActive(true);
                foreach (Transform childc in child.transform)
                {
                    if (childc.name != "alertText")
                    {
                        childc.gameObject.SetActive(true);

                    }
                }

                break;
            }
        }

        if (nowHourLinkOld [hour]== playerTouchTimes)
        {
            
            GameObject onMusic = GameObject.Find("onMusic");
            
            if (onMusic.GetComponent<homeMusic>().chap5Pass < 2)
            {
                this.showCard();
                GameObject alertText = GameObject.Find("alertText");
                alertText.GetComponent<Text>().text ="【"+oldHour[hour]+ "时】右侧为奖励卡片！点击卡片收纳入我的成就，可在我的成就中查看~";
            }
            else
            {
                GameObject alertText = GameObject.Find("alertText");
                alertText.GetComponent<Text>().text = "【" + oldHour[hour] + "时】成就卡片已达获取上限！";
            }

        }
        else 
        {
            GameObject alertText = GameObject.Find("alertText");
            alertText.GetComponent<Text>().text = "【" + oldHour[hour] + "时】时辰误报！";
        }

    }
    public void sureEnter()
    {
        try
        {
            GameObject alertWin = GameObject.Find("alertWin");
            alertWin.SetActive(true);
        }
        catch
        {
            GameObject Canvas = GameObject.Find("Canvas");
            foreach (Transform child in Canvas.transform)
            {
                if (child.name == "alertWin")
                {
                    child.gameObject.SetActive(true);
                }
            }

            Text alertText;
            alertText = GameObject.Find("alertText").GetComponent<Text>();
            alertText.text = "确定查看提示？";


            GameObject alertWin = GameObject.Find("alertWin");
            foreach (Transform child in alertWin.transform)
            {
                if (child.name == "sureButton")
                {
                    child.gameObject.SetActive(true);
                    child.GetComponent<Button>().interactable = true;
                }
            }
        }
        
        
    }
    public void showImage()
    {
        GameObject sureBtn = GameObject.Find("sureButton");
        sureBtn.GetComponent<Button>().interactable = false; 

        Text alertText;
        alertText = GameObject.Find("alertText").GetComponent<Text>();
        alertText.text = " ";
        GameObject alertWin = GameObject.Find("alertWin");
        foreach(Transform child in alertWin.transform)
        {
            if(child.name=="ScrollTip")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    public void closeTip()
    {
        GameObject alertWin = GameObject.Find("alertWin");
        alertWin.gameObject.SetActive(false);
        GameObject Finish = GameObject.Find("Finish");
        Finish.GetComponent<Button>().interactable = true;

    }
    public void hideImage()
    {
        try
        {
            GameObject ScrollTip = GameObject.Find("ScrollTip");
            ScrollTip.gameObject.SetActive(false);
            GameObject sureButton = GameObject.Find("sureButton");
            sureButton.gameObject.SetActive(false);
        }
        catch
        {

        }
        
    }

}

