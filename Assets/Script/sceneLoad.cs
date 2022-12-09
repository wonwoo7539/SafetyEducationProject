using System.Collections;
using System;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoad : MonoBehaviour
{
    public static sceneLoad instance = null;

    private int sceneNum;
    private List<int> randomList;

    public static Action Load;

    //public bool check = true;
    private void Awake()
    {/*
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
        */
        
        //randomList에 값 넣어주기
        ResetList();
    }

    public void Start()
    {
        Load = () => { SceneLoad(); };
    }
    private void Update()
    {
        
        
    }

    //reset List
    private void ResetList()
    {
        //random하게 불러올 씬 넘버
        randomList = new List<int>() {  1,2, 3, 4 ,5,6,7,8,9};
    }

    //chk current sceneNum
    private int ChkScneNum()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        return sceneNum;
    }

    //shuffle
    public void Mix()
    {
        //Debug.Log("Mix");
        List<int> list = new List<int>();
        int count = randomList.Count;
        for (int i = 0; i < count; i++)
        {
            int rand = UnityEngine.Random.Range(0, randomList.Count);
            list.Add(randomList[rand]);
            randomList.RemoveAt(rand);
        }
        randomList = list;
    }

    public void SceneLoad()
    {

        if (randomList.Count == 0 || randomList == null)
        {
            //SceneManager.LoadScene(12);
            //SceneManager.LoadScene(0);
            ResetList();
            SceneManager.LoadScene(randomList[0]);
            //Debug.Log(randomList.Count);
            randomList.RemoveAt(0);

            
        }
        else
        {
            //SceneManager.LoadScene(12);


            Mix();
            SceneManager.LoadScene(randomList[0]);
            //Debug.Log("남은 회수"+randomList.Count);
            randomList.RemoveAt(0);


        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(11);
    }
    
    public void ResultButton()
    {
        SceneManager.LoadScene(14);
    }

    public void MainButton()
    {
        SceneManager.LoadScene(0);
        GameManager.sum = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("겜종료");
    }
}