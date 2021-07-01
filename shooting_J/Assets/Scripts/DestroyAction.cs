using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAction : MonoBehaviour
{
    //나에게 부딪힌 대상을 제거한다.

    public PlayerFire pFire; //Player를 칸에 넣으면 Player가 갖고 있는 PlayerFire 컴포넌트만 들어감!!

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
        if(collision.gameObject.name != "Player")  //player에 예외처리
        {
            //충돌한 대상을 제거한다.(나한테 부딪힌 놈은 분명히 rigid body를 갖고 있을거야! 라고 가정)
            //Destroy(collision.gameObject);


            //총알이 나한테 닿으면 비활성화 시키기 
            if(collision.gameObject.name.Contains("Bullet"))
            {                
                collision.gameObject.SetActive(false);

                //충돌한 총알을 탄창 비활성화 리스트에 다시 추가한다.
                pFire.magazine.Add(collision.gameObject);
            }
        }
                    

        
    }


}
