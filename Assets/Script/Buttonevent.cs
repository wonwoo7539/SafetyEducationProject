using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonevent : MonoBehaviour
{
    public GameObject Txt; // 지문
    // 게임 9번 이미지
    public GameObject img1;
    public GameObject img2;

    public void Success()
    {
        GameManager.Suc();
        ScriptFail();
    }

    //RandPanel의 Rand함수를 받아와  2째 문제 실행
    public void Success1()
    {
       Txt.GetComponent<Text>().text="Q. 연기가 들어올때 행동요령 2"; // 맞추면 다음 문제 지문을 보여주게 한다. 
        Randpanel.Ran();
    }

    //게임 9번 버튼을 이용
    public void Success2()
    {
        img1.gameObject.SetActive(false);
        img2.gameObject.SetActive(true);
        GameManager.Suc();
        ScriptFail();
    }

    public void Fail()
    {
        GameManager.Fai();
        ScriptFail();
    }

    public void ScriptFail()
    {
        gameObject.GetComponent<Buttonevent>().enabled = false;
    }
}
