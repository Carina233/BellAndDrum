using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class passTest : MonoBehaviour
{
    
    int[] myCubeNum = new int[658];
    int[] yourCubeNum = new int[658];

    int[] myCubeNum1 = new int[] { 147,161,175,189,203,217,220,234,248,262,276,290,
        293,295,300,307,314,321,328,335,342,349,356,361,363,366,373,387,401,415,429,436,
        439,446,460,474,488,502,509
    };
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
    [System.Obsolete]
    void Start()
    {
        //Chapter3.0
        int i,j;
        for (i = 0; i <658; i++)
        {
            myCubeNum[i] = 0;
            for(j=0;j<myCubeNum1.Length;j++)
            {
                if(i==myCubeNum1[j])
                {
                    myCubeNum[i] = 1;
                }
            }
        }
        for (i = 74; i < 145; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 222; i < 233; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 236; i < 247; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 250; i < 261; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 264; i < 275; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 278; i < 289; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 368; i < 372; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 375; i < 386; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 389; i < 400; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 403; i < 414; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 417; i < 428; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 431; i < 435; i++)
        {
            myCubeNum[i] = 1;
        }
        for (i = 512; i < 583; i++)
        {
            myCubeNum[i] = 1;
        }
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
        {
            Debug.Log("onclickbutton");
            this.GetComponent<Button>().interactable = false;
            Pass3();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void closeAlertWin()
    {
        GameObject alertWin = GameObject.Find("alertWin");
        alertWin.SetActive(false);
        
        GameObject allCbFa = GameObject.Find("AllCubeFa");
        foreach(Transform child in allCbFa.transform)
        {
            child.gameObject.SetActive(true);
        }
        this.GetComponent<Button>().interactable = true;

    }
    public void clickCard()
    {

        GameObject cardRandom = GameObject.Find("cardRandom");
        Destroy(cardRandom);
        GameObject alertText = GameObject.Find("alertText");
        alertText.GetComponent<Text>().text = "成就卡已收录入我的成就，点击退出按键，开启下一关卡";
        GameObject onMusic = GameObject.Find("onMusic");
        onMusic.GetComponent<homeMusic>().chap3Pass += 1;
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
    [System.Obsolete]
    public void Pass3()
    {
        GameObject allCube = GameObject.Find("AllCube");
        int i=0 ;

        GameObject onMusic = GameObject.Find("onMusic");
        int pass = onMusic.GetComponent<homeMusic>().chap3Pass;
        //int j = 0;

        foreach (Transform child in allCube.transform)
        {
            if(child.gameObject.active==false)
            {
                //Debug.Log("foreach");
                yourCubeNum[i] = 1;
                i++;
            }
            else
            {
                //Debug.Log("elseforeach");
                yourCubeNum[i] = 0;
                i++;
            }
                //Debug.Log(child.gameObject.name);

        }
        for(i=0;i<myCubeNum.Length;i++)
        {
            if (myCubeNum[i] == yourCubeNum[i])
            {
                if (i == myCubeNum.Length - 1)
                {
                    //Debug.Log(i);
                    //GameObject text = GameObject.Find("tipText");
                    //text.GetComponent<Text>().text = "精心雕琢√";
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
                    if(pass<3)
                    {
                        GameObject alertText = GameObject.Find("alertText");
                        alertText.GetComponent<Text>().text = "精心雕琢√右侧为奖励卡片！点击卡片收纳入我的成就，可在我的成就中查看~";
                        this.showCard();

                    }
                    else
                    {
                        GameObject alertText = GameObject.Find("alertText");
                        alertText.GetComponent<Text>().text = "精心雕琢√成就卡片已达获取上限！";
                        Debug.Log("Win");
                    }
                    
                }
                continue;
            }
            else
            {
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
                alertText.GetComponent<Text>().text = "折戟沉沙,雕刻失误。";


                Debug.Log(i);
                //GameObject text = GameObject.Find("tipText");
                //text.GetComponent<Text>().text = "折戟沉沙,雕刻失误";
                Debug.Log("LOSE");
                return;
            }
            //Debug.Log(i+" "+yourCubeNum[i]);

        }
        
    }
}
