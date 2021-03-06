using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // 지정된 시간마다 에너미를 생성하고 싶다. 

    public GameObject EnemySource;
    public float makingTime = 2.0f;

    float currentTime = 0;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // 1. 현재 시간을 체크해서 지정된 시간이 되었는지 확인한다.(조건)
        if(currentTime == makingTime)
        {
            //  1-1. 나의 위치와 동일한 위치에 에너미를 생성한다. 
            GameObject go = Instantiate(EnemySource);
            go.transform.position = transform.position;

            //  1-2. 현재 시간을 0으로 초기화한다.
            currentTime = 0;


            // 2. 직전 프레임으로부터 현재 프레임까지 걸린 시간을 현재 시간 변수에 누적한다.



        }


        


    }
}
