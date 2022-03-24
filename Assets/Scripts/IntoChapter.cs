using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntoChapter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(transform.name);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
