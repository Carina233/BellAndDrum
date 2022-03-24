using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HomeToPages()
    {
        SceneManager.LoadScene("placesChoose");
    }
    public void PagesToAllChapters()
    {
        SceneManager.LoadScene("chaptersPage");
    }
    public void PagesToAchievement()
    {
        SceneManager.LoadScene("Achievement");
    }
    public void AchieventToPages()
    {
        SceneManager.LoadScene("placesChoose");
    }
    public void AllChaptersToPages()
    {
        SceneManager.LoadScene("placesChoose");
    }
    public void PagesToHome()
    {
        SceneManager.LoadScene("homePage");
    }

}
