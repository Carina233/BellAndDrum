using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chap2Pass : MonoBehaviour
{
    public int chooseNum = 0;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickMeiD()
    {
        GameObject MeiDbtn = GameObject.Find("MeiDBtn");
        GameObject OneoneBtn = GameObject.Find("OneoneBtn");
        GameObject ThreeoneBtn = GameObject.Find("ThreeoneBtn");
        MeiDbtn.GetComponent<Image>().color = new Color32(172, 209, 255, 255);
        OneoneBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        ThreeoneBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        chooseNum = 3;

    }
    public void onClickOneone()
    {
        GameObject MeiDbtn = GameObject.Find("MeiDBtn");
        GameObject OneoneBtn = GameObject.Find("OneoneBtn");
        GameObject ThreeoneBtn = GameObject.Find("ThreeoneBtn");
        MeiDbtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        OneoneBtn.GetComponent<Image>().color = new Color32(172, 209, 255, 255);
        ThreeoneBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        chooseNum = 2;
    }
    public void onClickThreeone()
    {
        GameObject MeiDbtn = GameObject.Find("MeiDBtn");
        GameObject OneoneBtn = GameObject.Find("OneoneBtn");
        GameObject ThreeoneBtn = GameObject.Find("ThreeoneBtn");
        MeiDbtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        OneoneBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        ThreeoneBtn.GetComponent<Image>().color = new Color32(172, 209, 255, 255);
        chooseNum = 1;
    }
    public void showCard()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        foreach (Transform child in Canvas.transform)
        {
            if (child.name == "cardRandom")
            {
                Image img = child.gameObject.GetComponent<Image>();

                cardRandomNum = Random.Range(0, 23);
                string imgName = cardName[cardRandomNum];

                string path = "Images/" + imgName;
                Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                Debug.Log(sprite);
                img.sprite = sprite;

                child.gameObject.SetActive(true);



            }
        }
    }
    public void clickCard()
    {

        GameObject cardRandom = GameObject.Find("cardRandom");
        Destroy(cardRandom);
        GameObject alertText = GameObject.Find("alertText");
        alertText.GetComponent<Text>().text = "成就卡已收录入我的成就，点击退出按键，开启下一关卡";
        GameObject onMusic = GameObject.Find("onMusic");

       
       
        onMusic.GetComponent<homeMusic>().chap2Pass += 1;
                
          


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
    public void chap2Finish()
    {
        GameObject gameFunc = GameObject.Find("gameFunction");
        foreach(Transform child in gameFunc.transform)
        {
            child.gameObject.SetActive(false);
        }
        GameObject gameObjectMTO = GameObject.Find("gameObjectMTO");
        gameObjectMTO.SetActive(false);

        GameObject Canvas = GameObject.Find("Canvas");
        foreach (Transform child in Canvas.transform)
        {
            if (child.name == "alertWin")
            {
                child.gameObject.SetActive(true);
                GameObject alertText = GameObject.Find("alertText");
                alertText.SetActive(true);
                break;
            }
        }
        GameObject onMusic = GameObject.Find("onMusic");
        if (chooseNum==1)
        {

            if(onMusic.GetComponent<homeMusic>().chap2Pass<2)
            {
                this.showCard();
                GameObject alertText = GameObject.Find("alertText");
                alertText.GetComponent<Text>().text = "回答正确,右侧为奖励卡片！点击卡片收纳入我的成就，可在我的成就中查看~";
            }
           else
            {
                GameObject alertText = GameObject.Find("alertText");
                alertText.GetComponent<Text>().text = "回答正确!成就卡片已达获取上限！";
            }

        }
        else if(chooseNum==0)
        {
            GameObject alertText = GameObject.Find("alertText");
            alertText.GetComponent<Text>().text = "未完成！";
        }
        else
        {
            GameObject alertText = GameObject.Find("alertText");
            alertText.GetComponent<Text>().text = "回答错误！";
        }
    }
    public void clickTip()
    {
        GameObject Canvas = GameObject.Find("Canvas");
        foreach(Transform child in Canvas.transform)
        {
            if(child.name=="alertWin")
            {
                child.gameObject.SetActive(true);
            }
        }
        GameObject alertWin = GameObject.Find("alertWin");
        foreach (Transform child in alertWin.transform)
        {
            if (child.name == "alertText")
            {
                child.gameObject.SetActive(false);
            }
            if(child.name=="ScrollTip")
            {
                child.gameObject.SetActive(true);
            }
            if (child.name == "Button")
            {
                child.gameObject.SetActive(true);
            }
        }
        GameObject gameFunc = GameObject.Find("gameFunction");
        foreach (Transform child in gameFunc.transform)
        {
            child.gameObject.SetActive(false);
        }
        GameObject gameObjectMTO = GameObject.Find("gameObjectMTO");
        gameObjectMTO.SetActive(false);
    }
    public void closeTip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
