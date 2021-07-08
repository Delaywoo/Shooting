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

        //���� ������ UI�� �ݿ��Ѵ�.
        scoreText[0].text = "���� ����: " + currentScore.ToString();


    }

    //�ɼ� â�� �����ϴ� �Լ�
    public void SetActiveOption(bool toggle)
    {
        //UIâ�� Ȱ��ȭ �Ѵ�.
        canvasUI.SetActive(toggle);

        //������Ʈ�� �ð��� �帧�� �����.
        if(toggle)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;

        }

                 
        
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

}
