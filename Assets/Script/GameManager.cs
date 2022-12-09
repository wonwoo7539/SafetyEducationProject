using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    // 다른 스크립트에 함수 호출 할 수 있도록 해주는 변수
    public static Action Suc;
    public static Action Fai;

    // 텍스트 UI 가져오기
    public GameObject suc;
    public GameObject fail;

    // 성공한 개수
    public static int sum = 0;
    // 실패한 개수
    public int FailCount;
    // 최대 실패 수
    public int Life;

    public void Awake()
    {
        // 다른 스크립트에서 함수 호출할 수 있도록 해준다.
        Suc = () => { Success(); };
        Fai = () => { Fail(); };
        Life = 4;
    }

    private void LateUpdate()
    {
        TimeOver();
    }

    // 시간 초과
    void TimeOver()
    {
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            Fail();
        }
    }

    public void Success()
    {
        //suc.gameObject.SetActive(true);
        TimerUI.Stimer = true;
        sum++; // 성공할때마다 하나씩 오르게 하기
        Debug.Log("sum의 개수" + sum);
        //suc.gameObject.SetActive(true);
        //Debug.Log("결과 playtime값: " + TimerUI.playTime);
        //Invoke("LoadScene", 1.0f);
        SceneManager.LoadScene(10);
        //sceneLoad.Load();
        TimerUI.DoTimerOffset();
        TimerUI.Stimer = false;
    }

    public void Fail()
    {
        TimerUI.Stimer = true;
        FailCount++; // 실패할때마다 하나씩 오르게 하기;
        //fail.gameObject.SetActive(true);
        //Debug.Log("결과 playtime값: " + TimerUI.playTime);
        //Debug.Log("life:"+(4-FailCount));
        //GameOver();
        SceneManager.LoadScene(12);
        TimerUI.DoTimerOffset();
        //Invoke("LoadScene", 1.0f);
        TimerUI.Stimer = false;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(10);
    }

    public void GameOver()
    {
        
        if(FailCount == 4)
        {
            //Debug.Log("게임오버");
            SceneManager.LoadScene(0);
            TimerUI.DoTimerOffset();
            TimerUI.Stimer = false;
            

        }
       
        
    }
}
