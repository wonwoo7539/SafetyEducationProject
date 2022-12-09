using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InGame : MonoBehaviour
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

    //��ư ������Ʈ
    public GameObject Button1;


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
        goalNum = 10;
    }

    /*
    // Update is called once per frame
    private void Update()
    {
        //�ð����� �ڵ�
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            gameObject.GetComponent<InGame>().enabled = false;
            fail.gameObject.SetActive(true);
        }
    }
    */

    //Ŭ���� ������ ����
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

    // ��ũ��Ʈ ��Ȱ��ȭ
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
