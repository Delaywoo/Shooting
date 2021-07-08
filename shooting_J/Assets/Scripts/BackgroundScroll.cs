using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    // material�� uv�� offset ������ y���� ������Ų��.
    // Material, MeshRenderer, offset(Vector2), ��ũ�� �ӵ�

    public float scrollSpeed = 0.5f;

    MeshRenderer mr;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        // 1. �޽� �������� �����´�.
        mr = GetComponent<MeshRenderer>();

        // 2. �޽� �������� 1�� ��Ƽ������ �����´�.
        mat = mr.materials[0];

        
    }

    // Update is called once per frame
    void Update()
    {
        // ��Ƽ������ uv offset ���� �����Ѵ�.
        mat.mainTextureOffset += Vector2.up * scrollSpeed * Time.deltaTime;
        
    }
}
