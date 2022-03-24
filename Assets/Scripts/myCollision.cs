using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class myCollision : MonoBehaviour
{

    private Rigidbody myRigidbody;
    public int OnCollisionOrNot;
    
    void Start()
    {
        OnCollisionOrNot = 1;
    }
   
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision myCollision)
    {
        if(OnCollisionOrNot==1)
        {
            //Debug.Log(myCollision.collider.transform.parent.name);
            
            if (myCollision.collider.transform.parent.GetComponent<Rigidbody>() != null)
            {
                myRigidbody = myCollision.collider.transform.parent.GetComponent<Rigidbody>();
                myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
               
            }
            else if(myCollision.collider.transform.parent.parent.GetComponent<Rigidbody>() != null)
            {
                myRigidbody = myCollision.collider.transform.parent.parent.GetComponent<Rigidbody>();
                myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
        }
        
        
        
    }
    private void OnCollisionStay(Collision myCollision)
    {

        
        if (OnCollisionOrNot == 1)
        {
            if(myCollision.collider.transform.parent.GetComponent<Rigidbody>()!=null)
            {
                myRigidbody = myCollision.collider.transform.parent.GetComponent<Rigidbody>();
                myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }

            else if(myCollision.collider.transform.parent.parent.GetComponent<Rigidbody>()!=null)
            {
                myRigidbody = myCollision.collider.transform.parent.parent.GetComponent<Rigidbody>();
                myRigidbody.constraints = RigidbodyConstraints.FreezePosition;
                myRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            }
            

        }

    }
    private void OnCollisionExit(Collision myCollision)
    {
        if(OnCollisionOrNot==1)
        {
            
            if(myCollision.collider.transform.parent.GetComponent<Rigidbody>()!=null)
            {
                myRigidbody = myCollision.collider.transform.parent.GetComponent<Rigidbody>();
                myRigidbody.constraints = ~RigidbodyConstraints.FreezePosition;
                myRigidbody.constraints = ~RigidbodyConstraints.FreezeRotation;
            }
            else if (myCollision.collider.transform.parent.parent.GetComponent<Rigidbody>()!=null)
            {
                myRigidbody = myCollision.collider.transform.parent.parent.GetComponent<Rigidbody>();
                myRigidbody.constraints = ~RigidbodyConstraints.FreezePosition;
                myRigidbody.constraints = ~RigidbodyConstraints.FreezeRotation;
            }


        }



    }


}
