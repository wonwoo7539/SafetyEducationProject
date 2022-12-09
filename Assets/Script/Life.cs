using System.Collections;
using System;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int Health;

    public bool Count;

    public Image[] UIHealth;

    public GameObject Heart;

    public static Action LifeMinus;
    private void Awake()
    {

        var obj = FindObjectsOfType<Life>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LifeMinus = () => { LifeSub(); };
        //DontDestroyOnLoad(gameObject);
        Heart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 10 || SceneManager.GetActiveScene().buildIndex == 11 || SceneManager.GetActiveScene().buildIndex == 12 || SceneManager.GetActiveScene().buildIndex == 13)
        {
            Heart.gameObject.SetActive(true);
            LifeCount(Health);
        }
        else
        {
            Heart.gameObject.SetActive(false);

        }

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            
            Health = 0;
            UIHealth[2].color = new Color(1, 1, 1, 1);
            UIHealth[1].color = new Color(1, 1, 1, 1);
            UIHealth[0].color = new Color(1, 1, 1, 1);
            
        }
        
    }

    public void LifeSub()
    {
        Health = Health - 1;
        //Debug.Log("Health" + Health);

        if (Health == -3)
        {
            SceneManager.LoadScene(13);
        }
    }

    public void LifeCount(int Life)
    {
        if (Life == 0)
        {

        }
        else if (Life == -1)
        {
            UIHealth[2].color = new Color(1, 0, 0, 0.4f);
        }
        else if (Life == -2)
        {
            UIHealth[2].color = new Color(1, 0, 0, 0.4f);
            UIHealth[1].color = new Color(1, 0, 0, 0.4f);
        }
        else
        {

            UIHealth[2].color = new Color(1, 0, 0, 0.4f);
            UIHealth[1].color = new Color(1, 0, 0, 0.4f);
            UIHealth[0].color = new Color(1, 0, 0, 0.4f);
        }
    }

    public void LifeReset()
    {
        Health = 3;
        SceneManager.LoadScene(0);
    }
}
