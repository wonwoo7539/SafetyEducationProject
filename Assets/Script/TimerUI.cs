using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    // 사용할 색을 저장한다.
    public Color highRate;
    public Color midRate;
    public Color lowRate;
    // 타임바로 움직이게 할 이미지
    public Image fill;

    [Header("Time")] // 매개변수를 헤더로 사용할 string 형식의 단어를 넘긴다.
    public static float maxTime = 5f;
    public static float playTime;
    // 슬라이더 UI 
    Slider mySlider;

    // 각 게임의 결과에 따라 타임바가 멈추게 하는 변수
    // GameManager Sun, Fai 함수에 있음
    public static bool Stimer;
    private void Awake()
    {
        // 매 Scene에서 playtime값을 0으로 초기화
        //playTime = 0.0f;

        //Debug.Log("현 씬의 playtime값: " + playTime);

        return;
    }
    void Start()
    {
        mySlider = GetComponent<Slider>(); // 슬라이더 UI 가져오기
    }

    public void Update()
    {
        GameTimer(); // 현재시간으로 계속 변환
    }

    public void LateUpdate()
    {
        TimerBar();
    }

    // 현재 시간
    public void GameTimer()
    {
        // GameManager 스크립트에서 성공한 개수를 sum에 저장하여 4개를 넘으면 1.5정도 속도를 높이고, 8개를 넘으면 속도를2배로 올린다.
        if (GameManager.sum >= 4 && GameManager.sum < 8 )
        {
            playTime += (Time.deltaTime * 1.5f);
            //Debug.Log("현재 속도=1.5f");
        }
        else if(GameManager.sum >= 8)
        {
            playTime += (Time.deltaTime * 2.5f);
            //Debug.Log("현재 속도=2.5f");
        }
        else
        {
            playTime += (Time.deltaTime*1.0f);
            //Debug.Log("sum = " + GameManager.sum);
            //Debug.Log("현재 속도=1.0f");
        }

        //Debug.Log("playTime: " + playTime);
    }

    // 움직이는 타이머 바
    public void TimerBar()
    {
        float remain = maxTime - playTime; // 남은 시간
        float rate = remain / maxTime; // 남은 시간 비율
        
        // 각 게임의 결과를 받으면 실행 
        if(Stimer == true)
        {
            OnDisable();
        }

        mySlider.value = rate; // 남은 시간 바에 표현

        // rate의 변화에 따라 색을 다르게 한다.
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

    //private void Awake()에서 초기화 시켜서 안써도 됨
    public static void DoTimerOffset()
    {
        //Debug.Log("현 씬의 playtime값: " + playTime);
        playTime = Time.deltaTime;
    }
    // 스크립트 비활성화
    private void OnDisable()
    {
        gameObject.GetComponent<TimerUI>().enabled = false;
    }
}
