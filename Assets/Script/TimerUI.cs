using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    // ����� ���� �����Ѵ�.
    public Color highRate;
    public Color midRate;
    public Color lowRate;
    // Ÿ�ӹٷ� �����̰� �� �̹���
    public Image fill;

    [Header("Time")] // �Ű������� ����� ����� string ������ �ܾ �ѱ��.
    public static float maxTime = 5f;
    public static float playTime;
    // �����̴� UI 
    Slider mySlider;

    // �� ������ ����� ���� Ÿ�ӹٰ� ���߰� �ϴ� ����
    // GameManager Sun, Fai �Լ��� ����
    public static bool Stimer;
    private void Awake()
    {
        // �� Scene���� playtime���� 0���� �ʱ�ȭ
        //playTime = 0.0f;

        //Debug.Log("�� ���� playtime��: " + playTime);

        return;
    }
    void Start()
    {
        mySlider = GetComponent<Slider>(); // �����̴� UI ��������
    }

    public void Update()
    {
        GameTimer(); // ����ð����� ��� ��ȯ
    }

    public void LateUpdate()
    {
        TimerBar();
    }

    // ���� �ð�
    public void GameTimer()
    {
        // GameManager ��ũ��Ʈ���� ������ ������ sum�� �����Ͽ� 4���� ������ 1.5���� �ӵ��� ���̰�, 8���� ������ �ӵ���2��� �ø���.
        if (GameManager.sum >= 4 && GameManager.sum < 8 )
        {
            playTime += (Time.deltaTime * 1.5f);
            //Debug.Log("���� �ӵ�=1.5f");
        }
        else if(GameManager.sum >= 8)
        {
            playTime += (Time.deltaTime * 2.5f);
            //Debug.Log("���� �ӵ�=2.5f");
        }
        else
        {
            playTime += (Time.deltaTime*1.0f);
            //Debug.Log("sum = " + GameManager.sum);
            //Debug.Log("���� �ӵ�=1.0f");
        }

        //Debug.Log("playTime: " + playTime);
    }

    // �����̴� Ÿ�̸� ��
    public void TimerBar()
    {
        float remain = maxTime - playTime; // ���� �ð�
        float rate = remain / maxTime; // ���� �ð� ����
        
        // �� ������ ����� ������ ���� 
        if(Stimer == true)
        {
            OnDisable();
        }

        mySlider.value = rate; // ���� �ð� �ٿ� ǥ��

        // rate�� ��ȭ�� ���� ���� �ٸ��� �Ѵ�.
        if (rate > 0.7f)
        {
            fill.color = highRate;
        }
        else if (rate > 0.4f)
        {
            fill.color = midRate;
        }
        else
        {
            fill.color = lowRate;
        }
    }

    //private void Awake()���� �ʱ�ȭ ���Ѽ� �Ƚᵵ ��
    public static void DoTimerOffset()
    {
        //Debug.Log("�� ���� playtime��: " + playTime);
        playTime = Time.deltaTime;
    }
    // ��ũ��Ʈ ��Ȱ��ȭ
    private void OnDisable()
    {
        gameObject.GetComponent<TimerUI>().enabled = false;
    }
}
