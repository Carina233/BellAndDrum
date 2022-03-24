using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class partIntroduction : MonoBehaviour
{
    private string[] bigTag = { "zuodou0", "zhengxinguagong0", "huagong","sheng", "gong", "ang" };
    private string[] bigText = { "坐斗","正心瓜拱","华拱","升","万拱","昂"};
    private string[] smallText = {"斗拱中承重的方形木块，承托横竖两个方向的重量，上开十字卯口。坐斗，又名打斗：宋《营造法式》称为栌斗。坐斗在全攒斗拱最底层，承托全攒重量的斗状方木块，开十字卯口。" ,
            "行如弓，与建筑物表面平行的称为拱，拱的中间有卯口，以承接与之相交的翘或昂，拱的两端向上弯曲如弓，其上安升子。按长短分为三种：瓜拱、万拱、厢拱；按位置分三种：正心拱、外拽拱、里拽拱"
            ,"古建筑构件名称。即直拱，又叫翅。垂直于建筑立面，向前后伸出的拱，为一朵斗拱中最主要的悬臂。华拱有单层或双层，每层谓之一“抄”。两头安小斗，名交叉斗、承横拱。"
            ,"拱与翘或昂交点之间，拱的两端与上层拱之间的斗状方木块。升只承托一个方向的重量，只开一字口。三才升：在各种外拽拱、里拽拱的两端，承托上层拱或枋。宋“营造法式”称为散斗。"
            ,"外拽万拱：宋《营造法式》称为单才万拱，在檐柱中心线内，与建筑物正面平行，里拽万拱之下为里拽瓜拱和两端三才升，里拽万拱之上为三才升、里拽枋。"
            ,"斗拱中在中心线上前后伸出，前端下斜带尖的木材部件称为昂，宋《营造法式》称为下昂，其功能与翘相同，形式不同。"};
    public int clickNum = 0;
    public string chooseTag;
    public string chooseName;
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
        Text myText3;
        myText3 = GameObject.Find("Text3").GetComponent<Text>();
        myText3.text = "请在右边选择与左侧描述一致的斗拱部件！";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickCard()
    {

        GameObject cardRandom = GameObject.Find("cardRandom");
        Destroy(cardRandom);
        GameObject alertText = GameObject.Find("alertText");
        alertText.GetComponent<Text>().text = "成就卡已收录入我的成就，点击退出按键，开启下一关卡";
        GameObject onMusic = GameObject.Find("onMusic");
        onMusic.GetComponent<homeMusic>().partIntroPass += 1;
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



        Debug.Log(onMusic.GetComponent<homeMusic>().partIntroPass);

    }
    public void clickNext()
    {
        GameObject onMusic = GameObject.Find("onMusic");
        int pass = onMusic.GetComponent<homeMusic>().partIntroPass;

        if (clickNum>=5)
        {

            GameObject Canvas = GameObject.Find("Canvas");
            foreach(Transform child in Canvas.transform)
            {
                if(child.name=="cardRandom")
                {
                    Image img = child.gameObject.GetComponent<Image>();

                    cardRandomNum = Random.Range(0, 23);
                    string imgName = cardName[cardRandomNum];

                    string path = "Images/"+imgName;
                    Sprite sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
                    Debug.Log(sprite);
                    img.sprite = sprite;

                    if(pass<2)
                    {
                        child.gameObject.SetActive(true);
                    }

                    
                }
            }
            


            GameObject DG = GameObject.Find("DG1");
            Destroy(DG);

            
            foreach (Transform child in Canvas.transform)
            {
                if (child.name == "alertWin")
                {
                    child.gameObject.SetActive(true);
                    foreach (Transform childc in child.transform)
                    {
                        if (childc.name != "alertText")
                        {
                            childc.gameObject.SetActive(false);
                        }
                        else
                        {
                            if(pass<2)
                            {
                                childc.GetComponent<Text>().text = "恭喜过关！右侧为奖励卡片！点击卡片收纳入我的成就，可在我的成就中查看~";
                                //onMusic.GetComponent<homeMusic>().partIntroPass += 1;
                            }
                            else
                            {
                                childc.GetComponent<Text>().text = "恭喜过关！成就卡片已达获取上限！";
                            }
                            GameObject nxBtn = GameObject.Find("nextBtn");
                            nxBtn.GetComponent<Button>().interactable = false;


                        }
                    }
                }
                
            }


            return;
        }
        Text myText3;
        myText3 = GameObject.Find("Text3").GetComponent<Text>();
        myText3.text = "请在右边选择与左侧描述一致的斗拱部件！";

        GameObject nextBtn = GameObject.Find("nextBtn");
        clickNum = nextBtn.GetComponent<partIntroduction>().clickNum;


        GameObject rightObj = GameObject.FindWithTag(bigTag[clickNum]);
        GameObject chooseObj = GameObject.Find(chooseName);
        chooseObj.GetComponent<HighlightableObject>().FlashingOff();
        try
        {
            rightObj.GetComponent<HighlightableObject>().FlashingOff();
        }
        catch
        {

        }

        
        if (clickNum<5)
        {
            clickNum++;
            nextBtn.GetComponent<partIntroduction>().clickNum = clickNum;
            GameObject Finish = GameObject.Find("Finish");
            Finish.GetComponent<partIntroduction>().clickNum = clickNum;

            Text myText;
            Text myText2;
            myText = GameObject.Find("Text").GetComponent<Text>();
            myText2 = GameObject.Find("Text2").GetComponent<Text>();


            myText.text = bigText[clickNum];
            myText2.text = smallText[clickNum];

           
        }
        //GameObject nextBtn = GameObject.Find("nextBtn");
        nextBtn.GetComponent<Button>().interactable = false;


        //清除发亮
        GameObject DG1= GameObject.Find("DG1");
        foreach (Transform child in DG1.transform)
        {
            child.GetComponent<HighlightableObject>().FlashingOff();
        }
    }
    public void clickFinish()
    {
        
        


        Text myText3;
        myText3 = GameObject.Find("Text3").GetComponent<Text>();

        GameObject Finish = GameObject.Find("Finish");
        clickNum=Finish.GetComponent<partIntroduction>().clickNum;

        
        GameObject DG1 = GameObject.Find("DG1");
        foreach(Transform child in DG1.transform)
        {
            if(child.tag==bigTag[clickNum])
            {
                child.GetComponent<HighlightableObject>().FlashingOn(Color.green, Color.green, 1f);
            }
        }
        



        //Debug.Log(rightObj.GetComponent<HighlightableObject>());

        GameObject chooseObj = GameObject.Find(chooseName);

        Debug.Log(chooseTag);
        Debug.Log(bigTag[clickNum]);
        


        if (chooseTag == bigTag[clickNum])
        {
            //rightObj.GetComponent<HighlightableObject>().FlashingOn(Color.green, Color.green, 1f);
            //chooseObj.GetComponent<HighlightableObject>().FlashingOn(Color.green, Color.green, 1f);

            myText3.text = "选择正确!点击下一步进入下一关！";

            if(clickNum==5)
            {
                myText3.text = "选择正确!点击完成本关吧！";
            }

        }
        else
        {
            if (clickNum != 5)
            {
                chooseObj.GetComponent<HighlightableObject>().FlashingOn(Color.red, Color.red, 1f);
                try
                {
                    //rightObj = GameObject.FindWithTag(bigTag[clickNum]);
                    //rightObj.GetComponent<HighlightableObject>().FlashingOn(Color.green, Color.green, 1f);
                }
                catch
                {

                }
                myText3.text = "选择错误欧，绿色显示的是正确答案！不要灰心，继续进入下一关！";
            }
            else
            {
                chooseObj.GetComponent<HighlightableObject>().FlashingOn(Color.red, Color.red, 1f);
                try
                {
                    //rightObj = GameObject.FindWithTag(bigTag[clickNum]);
                    //rightObj.GetComponent<HighlightableObject>().FlashingOn(Color.green, Color.green, 1f);
                }
                catch
                {

                }
                
                myText3.text = "选择错误欧，绿色显示的是正确答案！不要灰心，点击完成本关吧！";
            }
        }
        
        if(clickNum!=5)
        {
            GameObject nextBtn = GameObject.Find("nextBtn");
            nextBtn.GetComponent<Button>().interactable = true;
            //GameObject Finish = GameObject.Find("Finish");
            Finish.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            Finish.GetComponent<Button>().interactable = false;
        }
        else
        {
            GameObject nextBtn = GameObject.Find("nextBtn");
            nextBtn.GetComponent<Button>().interactable = true;

            GameObject nextText = GameObject.Find("nextText");
            nextText.GetComponent<Text>().text = "完成本关";

            //GameObject Finish = GameObject.Find("Finish");
            Finish.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            Finish.GetComponent<Button>().interactable = false;
        }
        

        
    }
}
