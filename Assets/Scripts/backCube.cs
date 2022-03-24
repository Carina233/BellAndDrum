using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class backCube : MonoBehaviour
{
    public int num = 0;
    public List<string> cubeBackList = new List<string>();
    public int resetMemory = 0;//重置回退数组

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        //Scene scene = SceneManager.GetActiveScene();

        //this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
        //{
        //    SceneManager.LoadScene(scene.name);
        //});
        this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
        {
            Debug.Log("onclickbutton");
            GameObject.Find("cubeControl").GetComponent<touchCube>().backmyCube();
        });
    }
    public void add ()
    {
        num++;
    }
    public void minus()
    {
        num--;
    }
    public void clearList()
    {
        Debug.Log("Clear???");
        cubeBackList.Clear();
        num = 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
