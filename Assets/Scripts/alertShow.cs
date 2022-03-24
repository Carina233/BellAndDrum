using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class alertShow : MonoBehaviour
{
    public int myFinish = 0;
    private int cardRandomNum;
    private int pass;
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
    
    public void gameReset()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);

    }

    //public void guidanceDrawing()
    //{

    //}


    [System.Obsolete]
    public void gameFinish()
    {
        //GameObject canvas = GameObject.Find("Canvas");

        //GameObject alertWin = canvas.transform.Find("alertWin").gameObject;
        //alertWin.gameObject.SetActive(true);

        GameObject group1 = GameObject.FindWithTag("group1");
        GameObject myGlobal;
        var f = 0;
        foreach (Transform child in group1.transform)
        {
            if(child.name=="Global")
            {
                myGlobal = child.gameObject;
                f = myGlobal.GetComponent<alertShow>().myFinish;
            }
        }

        
        foreach (Transform child in group1.transform)
        {

            if (child.gameObject.active == true)
            {

                f = 1;
                continue;
            }
            else
            {
                f = 0;
                break;
            }
        }


        GameObject DG = GameObject.Find("DG1");
        DG.SetActive(false);
        GameObject Text2 = GameObject.Find("Text2");
        Text2.SetActive(false);

        GameObject Canvas = GameObject.Find("Canvas");
        
        foreach (Transform child in Canvas.transform)
        {
            if(child.name=="alertWin")
            {
                child.gameObject.SetActive(true);
                
                foreach (Transform childc in child.transform)
                {
                    if(childc.name=="alertText")
                    {
                        if (f == 0)
                        {
                            GameObject.Find("alertText").GetComponent<Text>().text = "未完成";
                        }
                        else
                        {
                            GameObject onMusic = GameObject.Find("onMusic");
                            Scene scene = SceneManager.GetActiveScene();

                            
                            switch (scene.name)
                            {
                                case "Chapter1.0":
                                    pass = onMusic.GetComponent<homeMusic>().chap1_0Pass;
                                    break;
                                case "Chapter1.1":
                                    pass = onMusic.GetComponent<homeMusic>().chap1_1Pass;
                                    break;
                            }

                            if (pass < 2)
                            {
                                this.showCard();
                                GameObject.Find("alertText").GetComponent<Text>().text = "恭喜完成,右侧为奖励卡片！点击卡片收纳入我的成就，可在我的成就中查看~";
                            }
                            else
                            {
                                GameObject.Find("alertText").GetComponent<Text>().text = "恭喜过关！成就卡片已达获取上限！";
                                
                            }
                            
                            

                        }
                    }
                    else
                    {
                        childc.gameObject.SetActive(false);
                    }
                }
                
            }
        }
        

        //GameObject myGlobal = GameObject.Find("Global");
        //var f = myGlobal.GetComponent<alertShow>().myFinish;



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

        Scene scene = SceneManager.GetActiveScene();
        switch(scene.name)
        {
            case "Chapter1.0":
                onMusic.GetComponent<homeMusic>().chap1_0Pass += 1;
                break;
            case "Chapter1.1":
                onMusic.GetComponent<homeMusic>().chap1_1Pass += 1;
                break;
        }

        
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
    public void sculpture()
    {
        //GameObject text = GameObject.Find("tipText");
        //text.GetComponent<Text>().text = "退一步 柳暗花明";
        GameObject allCb = GameObject.Find("AllCube");
        allCb.SetActive(false);
        GameObject Canvas = GameObject.Find("Canvas");
        foreach (Transform child in Canvas.transform)
        {
            if (child.name == "alertWin")
            {
                child.gameObject.SetActive(true);

                break;
            }
        }
        GameObject alertText = GameObject.Find("alertText");
        alertText.GetComponent<Text>().text = "退一步,柳暗花明。";
    }
}
