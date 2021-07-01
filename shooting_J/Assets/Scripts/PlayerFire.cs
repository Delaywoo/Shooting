using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 사용자가 마우스 왼쪽 버튼을 클릭하면 총알을 생성하고 싶다.(발사까지는 말고, 생성만 !!)
    public GameObject bulletFactory;

    public Transform firePosition;

    [Range(1,5)]
    public int bulletCount = 1;

    public float total_gap = 8.0f;
    public float bullet_gap = 2.0f;


    //총알을 담을 탄창 배열 변수 -> 초기 개수값을 무조건 설정해놓아야함
    //public GameObject[] magazine = new GameObject[20];
    public List<GameObject> magazine = new List<GameObject>();
    public int magazineSize = 20;

    public GameObject wareHouse;

    // Start is called before the first frame update
    void Start()
    {
        // 시작하자마자 탄창에 총알을 가득 채운다!
        for(int i = 0; i < magazineSize; i++)
        {            
            //magazine의 i번째에 총알 만들어서 넣기
            GameObject go = Instantiate(bulletFactory);
            magazine.Add(go);   //List에 넣기        
            // magazine[i] = go;

            // 생성된 총알들을 비활성화한다.
            go.SetActive(false);

            //비활성화된 총알들을 창고의 자식 object로 등록한다.
            go.transform.parent = wareHouse.transform;
                                                
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FireNormalType();
            //FireSpecialType2();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            bulletCount = Mathf.Max(bulletCount - 1, 1); //둘중에 더 큰 값 -> 총알 개수가 1보다 더 작아질 수 없음
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            bulletCount = Mathf.Min(bulletCount + 1, 5); //둘중에 더 작은 값 -> 총알 개수가 5보다 더 커질수는 없음
        }
    }



    void FireNormalType()
    {
        
        if(bulletFactory != null)
        {   
            
            ////비활성화된 총알이 누군지 검색한다.
            //for(int i = 0; i < magazine.Length; i++)
            //{
            //    //만일 비활성화 되어있다면.. (magazine[i].activeInHierarchy == false) 또는 (!magazine[i].activeInHierarchy)
            //    if (!magazine[i].activeInHierarchy)  //activeInHierarchy : 활성화가 되어있는지 확인하는 bool 함수
            //    {
            //        magazine[i].SetActive(true);
            //        magazine[i].transform.position = firePosition.position;
            //        magazine[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); //회전각도 초기화
            //        break;
            //    }


            //}

            //가장 첫번째 총알을 활성화한다.
            //총알이 1개도 없으면 쏠 수 없기 때문에 탄창에 총알이 1개는 들어있는지를 먼저 확인해야함
            if(magazine.Count > 0)
            {
                magazine[0].SetActive(true);
                magazine[0].transform.position = firePosition.position;

                //활성화된 총알은 리스트로부터 제거한다.
                magazine.RemoveAt(0);
            }


        }
    }

    void FireMyType()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject go = Instantiate(bulletFactory);
            go.transform.position = firePosition.position + new Vector3(-0.5f * (bulletCount - 1), 0, 0) + new Vector3(i, 0, 0);

        }

        //(0) (-0.5,0.5) (-1,0,1) (-1.5,-0.5,0.5,1.5) (-2,-1,0,1,2)

    }

    void FireSpecialType1()  //전체 간격(total_gap)을 설정해놓기
    {
        //1. 앵커를 최대 범위의 좌측으로 잡는다.
        Vector3 anchor = new Vector3(total_gap * -0.5f, 1.2f, 0);

        //2. 앵커의 위치로부터 이동 간격 = 전체 범위 / (총알 갯수 + 1)
        float term = total_gap / (bulletCount + 1);

        // 3. 총알의 개수만큼 반복해서 앵커의 위치에서 이동 간격만큼 떨어진 곳에 총알을 생성한다. 
        for(int i = 0; i < bulletCount; i++)
        {
            GameObject go = Instantiate(bulletFactory);
            go.transform.position = transform.position + anchor + new Vector3(term * (i+1), 0, 0); //나의 위치를 기준으로 해야함!
        }
    }

    void FireSpecialType2() //총알 간의 간격(bullet_gap) 설정
    {
        ////1. 전체 범위(range)의 길이를 정한다. 
        //float range = bullet_gap * (bulletCount - 1);

        ////2. 앵커의 최대 범위의 좌측으로 잡는다.
        //Vector3 anchor = new Vector3(range * -0.5f, 1.2f, 0); //전체 범위(range)를 반반 나눠서 왼쪽 시작점을 anchor로 설정

        ////3. 총알의 개수만큼 반복해서 앵커 위치에서 이동 간격만큼 떨어진 곳에 총알을 생성한다.
        //for(int i = 0; i < bulletCount; i++)
        //{
        //    GameObject go = Instantiate(bulletFactory);
        //    go.transform.position = transform.position + anchor + new Vector3(bullet_gap * i, 0, 0);
        //}

        if(magazine.Count >= bulletCount)
        {
            for(int i = 0; i < bulletCount; i++)
            {
                magazine[0].SetActive(true);

                float range = bullet_gap * (bulletCount - 1);
                Vector3 anchor = new Vector3(range * -0.5f, 1.2f, 0);

                magazine[0].transform.position = transform.position + anchor + new Vector3(bullet_gap * i, 0, 0);

                magazine.RemoveAt(0);

            }

        }

    }

}
