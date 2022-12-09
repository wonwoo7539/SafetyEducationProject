using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindMove : MonoBehaviour, IDragHandler
{
    public float distance;

    public GameObject peo1;
    public GameObject peo2;
    public GameObject suc1;
    public GameObject suc2;
    public GameObject fai1;
    public GameObject fai2;

    private int random;

    void Awake()
    {
        // ������ �̿��ؼ� �׸� ��ġ �ٲٱ�
        random = UnityEngine.Random.Range(0, 2);

        if (random == 0) // 0�� �� �����ʿ� ����� ��ġ
        {
            peo1.gameObject.SetActive(true);
        }
        else // �������� ���ʿ� ��ġ
        {
            peo2.gameObject.SetActive(true);
        }

        //Debug.Log(random);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, 320.0f, distance); // new Vector3(x��ǥ, y��ǥ, z��ǥ)
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void LateUpdate()
    {
        TimeOver();
    }

    // Tag�� "Trap"�� "Goal"�� ������Ʈ�� �ε����� ��
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �̿��� ����� ��ġ�� �ٲ� ���� ����� �ٸ��� ��
        if(random == 1)
        {
            if (collision.gameObject.tag == "Trap")
            {
                //Debug.Log("Fail");
                fai1.gameObject.SetActive(true);
                GameManager.Fai();
                ScriptFail();
                return;
            }
            else if (collision.gameObject.tag == "Goal")
            {
                //Debug.Log("Claer");
                suc1.gameObject.SetActive(true);
                GameManager.Suc();
                ScriptFail();
                return;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Goal")
            {
                //Debug.Log("Fail");
                fai2.gameObject.SetActive(true);
                GameManager.Fai();
                ScriptFail();
                return;
            }
            else if (collision.gameObject.tag == "Trap")
            {
                //Debug.Log("Claer");
                suc2.gameObject.SetActive(true);
                GameManager.Suc();
                ScriptFail();
                return;
            }
        }
    }
    public void ScriptFail()
    {
        gameObject.GetComponent<WindMove>().enabled = false;
    }

    void TimeOver()
    {
        if (TimerUI.playTime > TimerUI.maxTime)
        {
            ScriptFail();
        }
    }
}
