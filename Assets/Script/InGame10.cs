using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame10 : MonoBehaviour
{
    //클릭수
    int myNum;
    //클릭해야할 목표수
    public int goalNum;

    //눌러야할 버튼
    public GameObject ciga;
    //성공 텍스트
    public GameObject suc;
    //실패 텍스트
    public GameObject fail;

    //유리 깨짐
    public GameObject BreakingGlass;

    //버튼 오브젝트
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;

    // 다른 스크립트에 함수 호출 할 수 있도록 해주는 변수
    public static Action Scr;


    private void Awake()
    {
        // 다른 스크립트에서 함수 호출할 수 있도록 해준다.
        Scr = () => { ScriptFail(); };
    }

    private void LateUpdate()
    {
        TimeOver();
    }
    // Start is called before the first frame update
    void Start()
    {
        //목표수 설정
        goalNum = 20;
        BreakingGlass.gameObject.SetActive(false);
    }

    // Update is called once per frame
    /*private void Update()
    {
        //시간제한 코드
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            gameObject.GetComponent<InGame10>().enabled = false;
            fail.gameObject.SetActive(true);
            Button1.gameObject.SetActive(false);
            Button2.gameObject.SetActive(false);
            Button3.gameObject.SetActive(false);
            Button4.gameObject.SetActive(false);
            Button5.gameObject.SetActive(false);
            BreakingGlass.gameObject.SetActive(false);

        }
    }*/

    //클릭시 실행할 내용
    public void Click()
    {
        //Debug.Log("Click");
        myNum++;
        //Debug.Log("mynum:" + myNum);
        if(myNum >= goalNum)
        {
            GameManager.Suc();
            ScriptFail();
            BreakingGlass.gameObject.SetActive(true);

            return;
        }
        
    }
    public void Click2()
    {
        //Debug.Log("Click");
        myNum= myNum+4;
        //Debug.Log("mynum:" + myNum);
        if (myNum >= goalNum)
        {
            ScriptFail();
            GameManager.Suc();
            BreakingGlass.gameObject.SetActive(true);


            return;
        }

    }

    // 스크립트 비활성화
    public void ScriptFail()
    {
        gameObject.GetComponent<InGame10>().enabled = false;
        Button1.gameObject.SetActive(false);
        Button2.gameObject.SetActive(false);
        Button3.gameObject.SetActive(false);
        Button4.gameObject.SetActive(false);
        Button5.gameObject.SetActive(false);
        BreakingGlass.gameObject.SetActive(false);
    }

    void TimeOver()
    {
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            GameManager.Fai();
            ScriptFail();
        }
    }
}
