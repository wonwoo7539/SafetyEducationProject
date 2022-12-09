using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame10 : MonoBehaviour
{
    //Ŭ����
    int myNum;
    //Ŭ���ؾ��� ��ǥ��
    public int goalNum;

    //�������� ��ư
    public GameObject ciga;
    //���� �ؽ�Ʈ
    public GameObject suc;
    //���� �ؽ�Ʈ
    public GameObject fail;

    //���� ����
    public GameObject BreakingGlass;

    //��ư ������Ʈ
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;
    public GameObject Button5;

    // �ٸ� ��ũ��Ʈ�� �Լ� ȣ�� �� �� �ֵ��� ���ִ� ����
    public static Action Scr;


    private void Awake()
    {
        // �ٸ� ��ũ��Ʈ���� �Լ� ȣ���� �� �ֵ��� ���ش�.
        Scr = () => { ScriptFail(); };
    }

    private void LateUpdate()
    {
        TimeOver();
    }
    // Start is called before the first frame update
    void Start()
    {
        //��ǥ�� ����
        goalNum = 20;
        BreakingGlass.gameObject.SetActive(false);
    }

    // Update is called once per frame
    /*private void Update()
    {
        //�ð����� �ڵ�
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

    //Ŭ���� ������ ����
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

    // ��ũ��Ʈ ��Ȱ��ȭ
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
