using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour, IDragHandler
{
    // 다른 스크립트에 함수 호출 할 수 있도록 해주는 변수
    public static Action Scr;
    // z축
    public float distance;

    private void Awake()
    {
        // 다른 스크립트에서 함수 호출할 수 있도록 해준다.
        Scr = () => { ScriptFail(); };
    }

    private void LateUpdate()
    {
        TimeOver();
    }

    // Tag가 "Trap"과 "Goal"인 오브젝트와 부딪혔을 때
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

    // 드래그를 이용한 오븥젝트 움직이기
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        this.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    // 스크립트 비활성화
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
