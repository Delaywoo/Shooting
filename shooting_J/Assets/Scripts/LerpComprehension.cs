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
            currentTime += Time.deltaTime / playSpeed;  //재생하는데에 걸리는 시간: time을 누적해서 원하는 시간으로 나눠준다.

            result = Mathf.Lerp(0, 1, currentTime);

            Vector4 ccolor = startcolor + new Vector4(0, 0, 0, result);



        }
        
        
    }
}
