using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myAchievement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject onMusic = GameObject.Find("onMusic");
        if(onMusic.GetComponent<homeMusic>().DouNiu>0)
        {
            GameObject card = GameObject.Find("DouNiu");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().Dragon > 0)
        {
            GameObject card = GameObject.Find("Dragon");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().HangShi > 0)
        {
            GameObject card = GameObject.Find("HangShi");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().Immortal > 0)
        {
            GameObject card = GameObject.Find("Immortal");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().Lion > 0)
        {
            GameObject card = GameObject.Find("Lion");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().Pegasus > 0)
        {
            GameObject card = GameObject.Find("Pegasus");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().Phoenix > 0)
        {
            GameObject card = GameObject.Find("Phoenix");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().Proteas > 0)
        {
            GameObject card = GameObject.Find("Proteas");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().SuanNi > 0)
        {
            GameObject card = GameObject.Find("SuanNi");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().XiaYu > 0)
        {
            GameObject card = GameObject.Find("XiaYu");
            card.GetComponent<Button>().interactable = true;
        }
        if (onMusic.GetComponent<homeMusic>().XieZhi > 0)
        {
            GameObject card = GameObject.Find("XieZhi");
            card.GetComponent<Button>().interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
