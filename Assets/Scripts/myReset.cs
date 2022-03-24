using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class myReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name=="Chapter1.0"||scene.name == "Chapter1.1")
        {
            this.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
            {
                //Destroy(GameObject.FindGameObjectWithTag("zuodou0").GetComponent<FixedJoint>());

                //Component[] fixedJoints;zuodou

                //fixedJoints = GetComponents(typeof(FixedJoint));

                //foreach (FixedJoint joint in fixedJoints)
                //    joint.enableCollision = true;

                Debug.Log("按了");
            });
        }
        
     }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void reloadReset()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);

    }
}
