using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLotto : MonoBehaviour
{
    // 1���� 45������ ���� �߿� �ϳ��� ���� 6�� ��÷�Ѵ�.
    // ��, �ߺ��Ǵ� ���� ����� ��.

    public int[] myNumbers = new int[6];

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < myNumbers.Length; i++)
            {
                int number = Random.Range(1, 46);
                myNumbers[i] = number;

                for (int j = 0; j < i ; j++)
                {
                    if (myNumbers[j] == number)
                    {
                        i--;
                        break;
                        
                    }                   
                                       
                }
                             
            }
                        
        }

    }
}
