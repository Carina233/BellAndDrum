
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Windows;

public class touchCube : MonoBehaviour
{

    //int resetMemory = 0;//重置回退数组
    string myName = null;
    //public string[] cubeArray = new string[10];
    //int num=0;
    List<string> cubeBackList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

        //resetMemory = 0;
        //num++;


        // Update is called once per frame
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        //num++;
        //没有触摸
        if (Input.touchCount <= 0)
        {
            return;

        }
        //单点触摸
        if (Input.touchCount == 1)
        {


            //float speed = 0.1f;
            //Touch touch = Input.GetTouch(0);

            //建立触摸屏幕点发射的射线
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //得到射线击到物体名称
            if (Physics.Raycast(ray, out hit))
            {
                //gameObject.AddComponent<Highlight>();
                //gameObject.AddComponent<HighlightableObject>();


                myName = hit.transform.name;

                //Debug.Log(myName);
                //Debug.Log(hit.transform.name);


            }
        }
            GameObject Cube = GameObject.Find(myName);
        //Material myMaterial = new Material(Shader.Find("Custom/afterTouchSurface"));

        //Cube.GetComponent<MeshRenderer>().material = myMaterial;
        //Debug.Log(myName);
        //Debug.Log(myMaterial.color);
        

        if (Cube)
            {
            //int myNum = GameObject.Find("Reset").GetComponent<backCube>().num;
            //Debug.Log("resetMemory"+resetMemory);
            if (GameObject.Find("Reset").GetComponent<backCube>().resetMemory == 1)
            {
                GameObject.Find("Reset").GetComponent<backCube>().clearList();
            }
            Cube.active = false;
            GameObject.Find("Reset").GetComponent<backCube>().cubeBackList.Add(Cube.name);

                Debug.Log(GameObject.Find("Reset").GetComponent<backCube>().cubeBackList[GameObject.Find("Reset").GetComponent<backCube>().num]);

                GameObject.Find("Reset").GetComponent<backCube>().add();

            //num++;
            GameObject.Find("Reset").GetComponent<backCube>().resetMemory = 0;
                Debug.Log(GameObject.Find("Reset").GetComponent<backCube>().num);
            myName = null;
            }
        


        }
    
    //public void onClickCube()
    //{
    //    Debug.Log("qqq");
    //    GameObject Cube = this.transform.gameObject;
    //    if (Cube)
    //    {
    //        Cube.SetActive(false);
    //        if (resetMemory == 1)
    //        {
                //cubeBackList.Clear();
                //num = 0;
    //        }
    //        cubeBackList.Add(Cube.name);

    //        Debug.Log(cubeBackList[num]);
    //        num++;
    //        resetMemory = 0;
    //    }
    //}
    [System.Obsolete]
    public void backmyCube()
    {
        Debug.Log(GameObject.Find("Reset").GetComponent<backCube>().num);
        if (GameObject.Find("Reset").GetComponent<backCube>().num > 0)
        {
           
            //GameObject myCube = GameObject.Find(cubeBackList[num-1]);
            //myCube.active = true;

            GameObject allCube = GameObject.Find("AllCube");
            foreach (Transform child in allCube.transform)
            {
                if (child.name == GameObject.Find("Reset").GetComponent<backCube>().cubeBackList[GameObject.Find("Reset").GetComponent<backCube>().num - 1])
                {
                    child.gameObject.SetActive(true);
                }
                //Debug.Log(child.gameObject.name);
            }
            GameObject.Find("Reset").GetComponent<backCube>().minus();
            GameObject.Find("Reset").GetComponent<backCube>().resetMemory = 1;
            //Debug.Log(num);
        }
        

    }
    
   

}


