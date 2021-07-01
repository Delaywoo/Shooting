using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // ������ �ð����� ���ʹ̸� �����ϰ� �ʹ�. 

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
        
        // 1. ���� �ð��� üũ�ؼ� ������ �ð��� �Ǿ����� Ȯ���Ѵ�.(����)
        if(currentTime == makingTime)
        {
            //  1-1. ���� ��ġ�� ������ ��ġ�� ���ʹ̸� �����Ѵ�. 
            GameObject go = Instantiate(EnemySource);
            go.transform.position = transform.position;

            //  1-2. ���� �ð��� 0���� �ʱ�ȭ�Ѵ�.
            currentTime = 0;


            // 2. ���� ���������κ��� ���� �����ӱ��� �ɸ� �ð��� ���� �ð� ������ �����Ѵ�.



        }


        


    }
}
