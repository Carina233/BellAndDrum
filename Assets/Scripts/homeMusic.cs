using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homeMusic : MonoBehaviour
{

    static homeMusic _instance;
    public int partIntroPass=0;
    public int chap1guidePass = 0;
    public int chap1_0Pass = 0;
    public int chap1_1Pass = 0;
    public int chap2Pass = 0;
    public int chap3Pass = 0;
    public int chap5Pass = 0;
    public string cardName;
    public int DouNiu = 0;
    public int Dragon = 0;
    public int HangShi = 0;
    public int Immortal = 0;
    public int Lion = 0;
    public int Pegasus = 0;
    public int Phoenix = 0;
    public int Proteas = 0;
    public int SuanNi = 0;
    public int XiaYu = 0;
    public int XieZhi = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public static homeMusic instance { 
        get
        {
            if(_instance==null)
            {
                _instance = FindObjectOfType<homeMusic>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
            }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this!=_instance)
        {
            Destroy(gameObject);
        }
    }





    public void clickMusic()
    {
       
    }

}
