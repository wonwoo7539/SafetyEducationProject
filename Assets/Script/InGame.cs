using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InGame : MonoBehaviour
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

    //버튼 오브젝트
    public GameObject Button1;


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
        goalNum = 10;
    }

    /*
    // Update is called once per frame
    private void Update()
    {
        //시간제한 코드
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            gameObject.GetComponent<InGame>().enabled = false;
            fail.gameObject.SetActive(true);
        }
    }
    */

    //클릭시 실행할 내용
    public void Click()
    {
        //Debug.Log("Click");
        myNum++;
        //Debug.Log("mynum:" + myNum);
        if(myNum == goalNum)
        {
            ScriptFail();
            GameManager.Suc();

            return;
        }
        
    }

    // 스크립트 비활성화
    public void ScriptFail()
    {
        gameObject.GetComponent<InGame>().enabled = false;
        Button1.gameObject.SetActive(false);
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
