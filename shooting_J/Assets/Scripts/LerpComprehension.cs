using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpComprehension : MonoBehaviour
{
    public float result = 1.0f;
    public float playSpeed = 1.0f;

    float currentTime = 0;

    Vector3 startPos;
    Vector4 startcolor;
    


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startcolor = new Vector4(0, 0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime < 1.0f)

        {
            currentTime += Time.deltaTime / playSpeed;  //����ϴµ��� �ɸ��� �ð�: time�� �����ؼ� ���ϴ� �ð����� �����ش�.

            result = Mathf.Lerp(0, 1, currentTime);

            Vector4 ccolor = startcolor + new Vector4(0, 0, 0, result);



        }
        
        
    }
}
