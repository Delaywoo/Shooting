using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    //�ɼ� �г��� ������ �ٽ� ������ �簳�ϴ� �Լ�
    public void Resume()
    {
        GameManager.gm.SetActiveOption(false);

    }


    // ������ �ٽ� �����ϵ��� �ϴ� �Լ�
    public void Restart()
    {
        SceneManager.LoadScene("ShootingMainScene");
        //SceneManager.LoadScene(0);
    }


    // ���� �����ϴ� �Լ�
    public void Quit()
    {
        Application.Quit();
    }




}
