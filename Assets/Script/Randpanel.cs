using UnityEngine;
using System;

public class Randpanel : MonoBehaviour
{
    // 첫번째 문제들
    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;


    // 두번째 문제들
    public GameObject bt4;
    public GameObject bt5;
    public GameObject bt6;

    private int random;

    // 다른 스크립트에서 함수를 쓸 수 있게 해준다.
    public static Action Ran;

    void Awake()
    {
        Ran = () => { Rand(); };

        // 랜덤을 이용해서 그림 위치 바꾸기
        random = UnityEngine.Random.Range(0, 3);

        // random으로 받은 수를 이용하여 각 그림 활성화
        switch (random)
        {
            case 0:
                bt1.gameObject.SetActive(true);
                break;
            case 1:
                bt2.gameObject.SetActive(true);
                break;
            case 2:
                bt3.gameObject.SetActive(true);
                break;
            default:
                Debug.Log("random에 없는 수 입니다.");
                break;
        }
        //Debug.Log(random);
    }

    // 2째 문제를 보여주는 함수
    public void Rand()
    {
        random = UnityEngine.Random.Range(0, 3); // 다시 한번 더 돌려서 랜덤하게 나오도록 한다.

        switch (random)
        {
            case 0:
                bt4.gameObject.SetActive(true);
                break;
            case 1:
                bt5.gameObject.SetActive(true);
                break;
            case 2:
                bt6.gameObject.SetActive(true);
                break;
            default:
                Debug.Log("random1에 없는 수 입니다.");
                break;
        }
        //Debug.Log(random);
    }
}
