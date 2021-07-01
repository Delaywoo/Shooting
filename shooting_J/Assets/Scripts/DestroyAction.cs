using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour
{
    //������ �ε��� ����� �����Ѵ�.

    public PlayerFire pFire; //Player�� ĭ�� ������ Player�� ���� �ִ� PlayerFire ������Ʈ�� ��!!

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "Player")  //player�� ����ó��
        {
            //�浹�� ����� �����Ѵ�.(������ �ε��� ���� �и��� rigid body�� ���� �����ž�! ��� ����)
            //Destroy(collision.gameObject);


            //�Ѿ��� ������ ������ ��Ȱ��ȭ ��Ű�� 
            if(collision.gameObject.name.Contains("Bullet"))
            {                
                collision.gameObject.SetActive(false);

                //�浹�� �Ѿ��� źâ ��Ȱ��ȭ ����Ʈ�� �ٽ� �߰��Ѵ�.
                pFire.magazine.Add(collision.gameObject);
            }
        }
                    

        
    }


}
