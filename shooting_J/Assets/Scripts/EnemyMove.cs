using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //1. 밑으로 내려간다 그저 한없이..    
    public float moveSpeed = 6.0f;

    //2. 플레이어가 있는 위치를 향해서 이동한다.
    GameObject player;


    // 확률에 따라 1번 또는 2번의 이동 방식을 사용한다. -> void Start
    // 0번이면 내려가기, 1번이면 쫓아가기
    int selection = 0;

    public int probability = 70; //70%로 내려가기, 30%로 쫓아가기

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");


        //확률에 따라서 1번 또는 2번의 이동 방식을 사용한다.
        int random_result = Random.Range(0, 101);

        if(random_result >= probability)
        {
            selection = 1;
        }

        print(selection);

        
       

    }

    // Update is called once per frame
    void Update()
    {

        if (selection == 0)
        {
            GoDown();
        }
        else
        {
            FollowPlayer();
        }


    }

    void GoDown()
    {
        transform.position += moveSpeed * Vector3.down * Time.deltaTime;  //한없이 밑으로 내려간다.
    }

    void FollowPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();

        transform.position += dir * moveSpeed * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            //옵션 창을 활성화 한다.
            GameManager.gm.SetActiveOption(true);
            //현재 점수를 저장한다.
            GameManager.gm.SaveScore();
            Destroy(gameObject);
        }
    }


}
