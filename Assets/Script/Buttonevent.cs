using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonevent : MonoBehaviour
{
    public GameObject Txt; // ����
    // ���� 9�� �̹���
    public GameObject img1;
    public GameObject img2;

    public void Success()
    {
        GameManager.Suc();
        ScriptFail();
    }

    //RandPanel�� Rand�Լ��� �޾ƿ�  2° ���� ����
    public void Success1()
    {
       Txt.GetComponent<Text>().text="Q. ���Ⱑ ���ö� �ൿ��� 2"; // ���߸� ���� ���� ������ �����ְ� �Ѵ�. 
        Randpanel.Ran();
    }

    //���� 9�� ��ư�� �̿�
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
