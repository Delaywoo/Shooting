using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    // material의 uv의 offset 값에서 y축을 증가시킨다.
    // Material, MeshRenderer, offset(Vector2), 스크롤 속도

    public float scrollSpeed = 0.5f;

    MeshRenderer mr;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // 1. 메쉬 렌더러를 가져온다.
        mr = GetComponent<MeshRenderer>();

        // 2. 메쉬 렌더러의 1번 머티리얼을 가져온다.
        mat = mr.materials[0];

        
    }

    // Update is called once per frame
    void Update()
    {
        // 머티리얼의 uv offset 값을 변경한다.
        mat.mainTextureOffset += Vector2.up * scrollSpeed * Time.deltaTime;
        
    }
}
