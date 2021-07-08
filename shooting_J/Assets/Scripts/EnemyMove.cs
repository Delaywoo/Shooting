using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //1. ������ �������� ���� �Ѿ���..    
    public float moveSpeed = 6.0f;

    //2. �÷��̾ �ִ� ��ġ�� ���ؼ� �̵��Ѵ�.
    GameObject player;


    // Ȯ���� ���� 1�� �Ǵ� 2���� �̵� ����� ����Ѵ�. -> void Start
    // 0���̸� ��������, 1���̸� �Ѿư���
    int selection = 0;

    public int probability = 70; //70%�� ��������, 30%�� �Ѿư���

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");


        //Ȯ���� ���� 1�� �Ǵ� 2���� �̵� ����� ����Ѵ�.
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
        transform.position += moveSpeed * Vector3.down * Time.deltaTime;  //�Ѿ��� ������ ��������.
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
            //�ɼ� â�� Ȱ��ȭ �Ѵ�.
            GameManager.gm.SetActiveOption(true);
            //���� ������ �����Ѵ�.
            GameManager.gm.SaveScore();
            Destroy(gameObject);
        }
    }


}
