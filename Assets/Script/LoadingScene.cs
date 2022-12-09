using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    Life Life;
    LifeManager LifeManager;

    public GameObject ResultButton;
    // Start is called before the first frame update
    void Start()
    {
        //ResultButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void successEvent()
    {
        //Debug.Log("Event");
        SceneManager.LoadScene("Next");
      
    }

    

    public void nextStage()
    {
      

        sceneLoad.Load();

    }

    public void FailStart()
    {
        Life.LifeMinus();
        
    }
    public void FailEvent()
    {
        SceneManager.LoadScene("Next");
    }

    public void LifeView()
    {
        //int a = Life.Health;
    }

    public void GameOver()
    {
        ResultButton.gameObject.SetActive(true);
    }
}
