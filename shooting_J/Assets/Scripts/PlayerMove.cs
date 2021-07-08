using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // 사용자의 입력을 받아서 상하 또는 좌우로 이동을 하고 싶다.
    // 사용자의 입력: 좌우 화살표 키, 상하 화살표 키, WASD 키
    // 이동 필요 요소: 속도(방향+속력), 시간
    // A-B : B가 A를 향하는 벡터

    public float moveSpeed = 0.1f;


    float finalSpeed = 0;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        finalSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()  //일정한 시간에 한번씩 업데이트되는것
    {
        //if(Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    print("나는 니가 윗쪽 화살표 키를 누른 것을 알고 있다 ..");
        //}

        float h = Input.GetAxis("Horizontal");        //input manager에서 사용하고자 하는 name 복사
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, v, 0);  //0: z축의 방향으로는 이동시키지 않겠다는 것을 의미, 값이 안들어 있는게 아님!
        direction.Normalize(); // normalize(정규화) 함수

        // direction에 정해진 방향대로 이동하고 싶다.
        // p = p0 + vt

        // 좌측 Shift 키를 누른 상태일 때에는 속도가 2배로 증가한다.

        transform.position += direction * moveSpeed * Time.deltaTime;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed = moveSpeed * 2;

        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            finalSpeed = moveSpeed;
        }

        // 좌측 Shiflt 키에서 손을 떼면 다시 원래 속도대로 돌아온다.
        

        // 이번 프레임에 도착할 지점까지의 거리를 구한다.
        Vector3 arrivePos = direction * finalSpeed * Time.deltaTime;

        // 현재 위치에서 도착 지점까지 레이를 발사해본다.
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, arrivePos.magnitude))
        {

            if(hitInfo.distance < arrivePos.magnitude)
            {
                transform.position = hitInfo.point;
                transform.position -= direction * 0.5f;

            }
            
        }

        else
        {
            rb.velocity = direction * finalSpeed;

        }



        //플레이어의 월드 좌표를 뷰포트 좌표로 환산한다.
        //Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        //환산된 뷰포트 좌표를 0~1 사이의 값으로 제한한다.
        //viewPos.x = Mathf.Clamp01(viewPos.x);
        //viewPos.y = Mathf.Clamp01(viewPos.y);


        //제한 적용된 뷰포트 좌표를 월드 좌표로 변환해서 플레이어 포지션으로 덮어쓴다.
        //transform.position = Camera.main.ViewportToWorldPoint(viewPos);
        
        


    }
}
