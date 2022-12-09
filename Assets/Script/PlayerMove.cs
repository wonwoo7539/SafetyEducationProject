using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour, IDragHandler
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

    // Tag�� "Trap"�� "Goal"�� ������Ʈ�� �ε����� ��
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

    // �巡�׸� �̿��� ������Ʈ �����̱�
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    // ��ũ��Ʈ ��Ȱ��ȭ
    public void ScriptFail()
    {
        gameObject.GetComponent<PlayerMove>().enabled = false;
    }

    void TimeOver()
    {
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            ScriptFail();
        }
    }
}
