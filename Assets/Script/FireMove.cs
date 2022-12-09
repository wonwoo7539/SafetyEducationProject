using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireMove : MonoBehaviour, IDragHandler
{
    // �ٸ� ��ũ��Ʈ�� �Լ� ȣ�� �� �� �ֵ��� ���ִ� ����
    public static Action Scr;
    // z��
    public float distance;

    private void Awake()
    {
        // �ٸ� ��ũ��Ʈ���� �Լ� ȣ���� �� �ֵ��� ���ش�.
        Scr = () => { ScriptFail(); };
    }

    private void LateUpdate()
    {
        TimeOver();
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Trap")
        {
            //Debug.Log("Fail");
            GameManager.Fai();
            ScriptFail();
            return;
        }
        else if (collision.gameObject.tag == "Goal")
        {
            //Debug.Log("Claer");
            GameManager.Suc();
            ScriptFail();
            return;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        /*
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
        */
    }

    // ��ũ��Ʈ ��Ȱ��ȭ
    public void ScriptFail()
    {
        gameObject.GetComponent<FireMove>().enabled = false;
    }

    void TimeOver()
    {
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            ScriptFail();
        }
    }
}
