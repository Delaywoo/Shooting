using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // single tone pattern....
    public static GameManager gm; //static: 우선적으로 놓고, 앱이 종료될 때까지 사라지지 않는 변수, 프로젝트 전체에서 static 변수는 딱 하나여야함.

    public GameObject canvasUI;

    public Text[] scoreText = new Text[2];

    public int currentScore = 0;
    public int bestScore = 0;

    float currentTime;

    


    bool fadeStart = false;

    public Image backImage;
    public Text label;

    Color startImageColor;
    Color startlabelColor;
    int startFontSize;



    private void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        startImageColor = backImage.color;
        startlabelColor = label.color;
        startFontSize = label.fontSize;


        SetActiveOption(false);
        LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetActiveOption(true);
        }

        //현재 점수를 UI에 반영한다.
        scoreText[0].text = "현재 점수: " + currentScore.ToString();

        // 페이드 이펙트를 실행한다.
        if (fadeStart)
        {
            FadeEffect();
        }

    }

    //옵션 창을 생성하는 함수
    public void SetActiveOption(bool toggle)
    {
        
        //UI창을 활성화 한다.
        canvasUI.SetActive(toggle);

        fadeStart = toggle;



        //오브젝트의 시간의 흐름을 멈춘다.
        //if(toggle)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;

        //}

                 
        
    }

    //최고 스코어를 저장 장치에 저장한다.
    public void SaveScore()
    {
        //만일, 현재 점수가 최고 점수를 넘어갔다면 ...
        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt("score", currentScore);
            print("저장 완료됐습니다.");

        }

        
    }

    // 저장된 점수를 최고 점수로 출력한다.
    void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("score");

        scoreText[1].text = "최고 점수: " + bestScore.ToString();
    }


    void FadeEffect()
    {
        // 값을 최초 저장한 값에서 목표한 값으로 시간의 흐름에 따라 변화시키고 싶다. 
        // Lerp 함수
        if(currentTime < 1.0)
        {
            currentTime += Time.deltaTime;

            float alpha = Mathf.Lerp(startImageColor.a, 0.8f, currentTime);
            backImage.color = new Color(startImageColor.r, startImageColor.g, startImageColor.b, alpha);
            //backImage.color = Color.Lerp(startImageColor, new Color(startImageColor.r, startImageColor.g, startImageColor.b, 0.8f), currentTime);

            float alpha2 = Mathf.Lerp(startlabelColor.a, 1.0f, currentTime);
            label.color = startlabelColor + new Color(0, 0, 0, alpha2);

            int size = (int)Mathf.Lerp((float)startFontSize, 90.0f, currentTime);
            label.fontSize = size;


        }
        else
        {
            Time.timeScale = 0;
            fadeStart = false;
        }    



    }

}
