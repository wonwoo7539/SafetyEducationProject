using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    // �ٸ� ��ũ��Ʈ�� �Լ� ȣ�� �� �� �ֵ��� ���ִ� ����
    public static Action Suc;
    public static Action Fai;

    // �ؽ�Ʈ UI ��������
    public GameObject suc;
    public GameObject fail;

    // ������ ����
    public static int sum = 0;
    // ������ ����
    public int FailCount;
    // �ִ� ���� ��
    public int Life;

    public void Awake()
    {
        // �ٸ� ��ũ��Ʈ���� �Լ� ȣ���� �� �ֵ��� ���ش�.
        Suc = () => { Success(); };
        Fai = () => { Fail(); };
        Life = 4;
    }

    private void LateUpdate()
    {
        TimeOver();
    }

    // �ð� �ʰ�
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
        sum++; // �����Ҷ����� �ϳ��� ������ �ϱ�
        Debug.Log("sum�� ����" + sum);
        //suc.gameObject.SetActive(true);
        //Debug.Log("��� playtime��: " + TimerUI.playTime);
        //Invoke("LoadScene", 1.0f);
        SceneManager.LoadScene(10);
        //sceneLoad.Load();
        TimerUI.DoTimerOffset();
        TimerUI.Stimer = false;
    }

    public void Fail()
    {
        TimerUI.Stimer = true;
        FailCount++; // �����Ҷ����� �ϳ��� ������ �ϱ�;
        //fail.gameObject.SetActive(true);
        //Debug.Log("��� playtime��: " + TimerUI.playTime);
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
            //Debug.Log("���ӿ���");
            SceneManager.LoadScene(0);
            TimerUI.DoTimerOffset();
            TimerUI.Stimer = false;
            

        }
       
        
    }
}
