using UnityEngine;
using System;

public class Randpanel : MonoBehaviour
{
    // ù��° ������
    public GameObject bt1;
    public GameObject bt2;
    public GameObject bt3;


    // �ι�° ������
    public GameObject bt4;
    public GameObject bt5;
    public GameObject bt6;

    private int random;

    // �ٸ� ��ũ��Ʈ���� �Լ��� �� �� �ְ� ���ش�.
    public static Action Ran;

    void Awake()
    {
        Ran = () => { Rand(); };

        // ������ �̿��ؼ� �׸� ��ġ �ٲٱ�
        random = UnityEngine.Random.Range(0, 3);

        // random���� ���� ���� �̿��Ͽ� �� �׸� Ȱ��ȭ
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
                Debug.Log("random�� ���� �� �Դϴ�.");
                break;
        }
        //Debug.Log(random);
    }

    // 2° ������ �����ִ� �Լ�
    public void Rand()
    {
        random = UnityEngine.Random.Range(0, 3); // �ٽ� �ѹ� �� ������ �����ϰ� �������� �Ѵ�.

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
                Debug.Log("random1�� ���� �� �Դϴ�.");
                break;
        }
        //Debug.Log(random);
    }
}
