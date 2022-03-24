using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class QuitToAllChapter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("chaptersPage");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
