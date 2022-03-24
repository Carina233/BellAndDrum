using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RightOrNot : MonoBehaviour
{
    public int step = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject group1 = GameObject.FindWithTag("group1");
        foreach (Transform child in group1.transform)
        {
            //if ()
            //{
                

            //}

        }
    }
    //int maxDistance = 2;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tringggggggggg");
       
        step++;

        if (!GetComponent<FixedJoint>())
        {
            var fixedJ = new FixedJoint();//固定关节
            if (GetComponent<Rigidbody>())
            {
                //如果碰撞体是刚体
                //Debug.Log(this.gameObject);
                transform.gameObject.AddComponent<FixedJoint>();//加固定关节
                                                                // Debug.Log(this.gameObject.GetComponent<HingeJoint>().connectedBody);
                
                if(other.transform.GetComponent<Rigidbody>())
                {
                    transform.gameObject.GetComponent<FixedJoint>().connectedBody = other.transform.GetComponent<Rigidbody>();//设置固定关节的另一个连接的刚体
                }

                transform.gameObject.GetComponent<FixedJoint>().massScale = 100;
                transform.gameObject.GetComponent<FixedJoint>().connectedMassScale = 100;

                
                Time.timeScale = 0;
                GameObject group1 = GameObject.FindWithTag("group1");
                foreach(Transform child in group1.transform)
                {
                    if(child.gameObject.name== other.transform.gameObject.name|| child.gameObject.name == transform.gameObject.name)
                    {
                        child.gameObject.SetActive(true);
                        
                    }
                    
                    Debug.Log(child.gameObject.name);
                }

                int pp = 0;
                try
                {
                    if(other.transform.parent.parent.gameObject)
                    {
                        if(other.transform.parent.parent.gameObject.name=="group1")
                        {
                            Debug.Log("1");
                            pp = 1;
                        }
                        
                    }
                    
                }
                catch
                {
                    
                }

                Debug.Log(pp);
                //其他与其他物件碰撞
                if (other.transform.parent.gameObject.name!="group1"&&transform.parent.gameObject.name!= "group1"&&pp!=1)
                {

                    Destroy(other.transform.gameObject);
                    Destroy(transform.gameObject);
                }
                //其他与group1碰撞
                else if (other.transform.parent.gameObject.name == "group1"||pp==1)
                {
                    Destroy(transform.gameObject);
                }
                else if (transform.parent.gameObject.name == "group1")
                {
                    Destroy(other.transform.gameObject);
                }

                Time.timeScale = 1;

                


            }

        }
    }
}
