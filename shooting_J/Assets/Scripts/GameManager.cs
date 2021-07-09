using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // single tone pattern....
    public static GameManager gm; //static: �켱������ ����, ���� ����� ������ ������� �ʴ� ����, ������Ʈ ��ü���� static ������ �� �ϳ�������.

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

        //���� ������ UI�� �ݿ��Ѵ�.
        scoreText[0].text = "���� ����: " + currentScore.ToString();

        // ���̵� ����Ʈ�� �����Ѵ�.
        if (fadeStart)
        {
            FadeEffect();
        }

    }

    //�ɼ� â�� �����ϴ� �Լ�
    public void SetActiveOption(bool toggle)
    {
        
        //UIâ�� Ȱ��ȭ �Ѵ�.
        canvasUI.SetActive(toggle);

        fadeStart = toggle;



        //������Ʈ�� �ð��� �帧�� �����.
        //if(toggle)
        //{
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;

        //}

                 
        
    }

    //�ְ� ���ھ ���� ��ġ�� �����Ѵ�.
    public void SaveScore()
    {
        //����, ���� ������ �ְ� ������ �Ѿ�ٸ� ...
        if(currentScore > bestScore)
        {
            PlayerPrefs.SetInt("score", currentScore);
            print("���� �Ϸ�ƽ��ϴ�.");

        }

        
    }

    // ����� ������ �ְ� ������ ����Ѵ�.
    void LoadScore()
    {
        bestScore = PlayerPrefs.GetInt("score");

        scoreText[1].text = "�ְ� ����: " + bestScore.ToString();
    }


    void FadeEffect()
    {
        // ���� ���� ������ ������ ��ǥ�� ������ �ð��� �帧�� ���� ��ȭ��Ű�� �ʹ�. 
        // Lerp �Լ�
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
