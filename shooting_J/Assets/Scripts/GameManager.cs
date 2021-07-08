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


    }

    //옵션 창을 생성하는 함수
    public void SetActiveOption(bool toggle)
    {
        //UI창을 활성화 한다.
        canvasUI.SetActive(toggle);

        //오브젝트의 시간의 흐름을 멈춘다.
        if(toggle)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;

        }

                 
        
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

}
