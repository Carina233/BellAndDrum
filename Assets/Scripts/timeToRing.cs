using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeToRing : MonoBehaviour
{
    private int hour;
    private int min;
    private int second;
    private int on = 0;
    int times;
    int count;

    // Start is called before the first frame update
    void Start()
    {
      
        
    }
    //按时辰敲钟
    public void callManyTimes()
    {
        GameObject bell = GameObject.Find("Bell");
        AudioSource audioS = bell.GetComponent<AudioSource>();
        audioS.Play();
        //audioS.loop = true;
        count++;
        Debug.Log(count);
        Debug.Log(times);
        if (count == times)

        {
            on = 0;
            CancelInvoke("callManyTimes");
            
        }

    }
    void Update()
    {
       

        hour = DateTime.Now.Hour;
        min = DateTime.Now.Minute;
        second = DateTime.Now.Second;

        

        
        if (min == 0 && second == 0 && on ==0 && (hour+1)%2==0)
        {
            times = hour % 12;
            on = 1;
            
            Debug.Log("444444444");
            InvokeRepeating("callManyTimes", 0, 2f);
            //toRing();
        }
       


    }
}
