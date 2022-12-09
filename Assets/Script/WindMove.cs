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
        // 랜덤을 이용해서 그림 위치 바꾸기
        random = UnityEngine.Random.Range(0, 2);

        if (random == 0) // 0일 때 오른쪽에 사람이 위치
        {
            peo1.gameObject.SetActive(true);
        }
        else // 나머지는 왼쪽에 위치
        {
            peo2.gameObject.SetActive(true);
        }

        //Debug.Log(random);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, 320.0f, distance); // new Vector3(x좌표, y좌표, z좌표)
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void LateUpdate()
    {
        TimeOver();
    }

    // Tag가 "Trap"과 "Goal"인 오브젝트와 부딪혔을 때
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // 랜덤을 이용해 사람의 위치가 바뀜에 따라 결과를 다르게 함
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
