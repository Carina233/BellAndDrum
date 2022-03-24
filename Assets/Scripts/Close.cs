using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
        {
            GameObject Image = GameObject.FindWithTag("Image");
            Debug.Log(Image.tag);
            Image.transform.GetChild(0).gameObject.SetActive(false);
            Image.transform.GetChild(1).gameObject.SetActive(false);
            
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
