using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    //옵션 패널이 닫히고 다시 게임을 재개하는 함수
    public void Resume()
    {
        GameManager.gm.SetActiveOption(false);

    }


    // 게임을 다시 시작하도록 하는 함수
    public void Restart()
    {
        SceneManager.LoadScene("ShootingMainScene");
        //SceneManager.LoadScene(0);
    }


    // 앱을 종료하는 함수
    public void Quit()
    {
        Application.Quit();
    }




}
