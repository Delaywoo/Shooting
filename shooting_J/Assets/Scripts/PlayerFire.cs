using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // ����ڰ� ���콺 ���� ��ư�� Ŭ���ϸ� �Ѿ��� �����ϰ� �ʹ�.(�߻������ ����, ������ !!)
    public GameObject bulletFactory;

    public Transform firePosition;

    [Range(1,5)]
    public int bulletCount = 1;

    public float total_gap = 8.0f;
    public float bullet_gap = 2.0f;


    //�Ѿ��� ���� źâ �迭 ���� -> �ʱ� �������� ������ �����س��ƾ���
    //public GameObject[] magazine = new GameObject[20];
    public List<GameObject> magazine = new List<GameObject>();
    public int magazineSize = 20;

    public GameObject wareHouse;

    // Start is called before the first frame update
    void Start()
    {
        // �������ڸ��� źâ�� �Ѿ��� ���� ä���!
        for(int i = 0; i < magazineSize; i++)
        {            
            //magazine�� i��°�� �Ѿ� ���� �ֱ�
            GameObject go = Instantiate(bulletFactory);
            magazine.Add(go);   //List�� �ֱ�        
            // magazine[i] = go;

            // ������ �Ѿ˵��� ��Ȱ��ȭ�Ѵ�.
            go.SetActive(false);

            //��Ȱ��ȭ�� �Ѿ˵��� â���� �ڽ� object�� ����Ѵ�.
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
            bulletCount = Mathf.Max(bulletCount - 1, 1); //���߿� �� ū �� -> �Ѿ� ������ 1���� �� �۾��� �� ����
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            bulletCount = Mathf.Min(bulletCount + 1, 5); //���߿� �� ���� �� -> �Ѿ� ������ 5���� �� Ŀ������ ����
        }
    }



    void FireNormalType()
    {
        
        if(bulletFactory != null)
        {   
            
            ////��Ȱ��ȭ�� �Ѿ��� ������ �˻��Ѵ�.
            //for(int i = 0; i < magazine.Length; i++)
            //{
            //    //���� ��Ȱ��ȭ �Ǿ��ִٸ�.. (magazine[i].activeInHierarchy == false) �Ǵ� (!magazine[i].activeInHierarchy)
            //    if (!magazine[i].activeInHierarchy)  //activeInHierarchy : Ȱ��ȭ�� �Ǿ��ִ��� Ȯ���ϴ� bool �Լ�
            //    {
            //        magazine[i].SetActive(true);
            //        magazine[i].transform.position = firePosition.position;
            //        magazine[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); //ȸ������ �ʱ�ȭ
            //        break;
            //    }


            //}

            //���� ù��° �Ѿ��� Ȱ��ȭ�Ѵ�.
            //�Ѿ��� 1���� ������ �� �� ���� ������ źâ�� �Ѿ��� 1���� ����ִ����� ���� Ȯ���ؾ���
            if(magazine.Count > 0)
            {
                magazine[0].SetActive(true);
                magazine[0].transform.position = firePosition.position;

                //Ȱ��ȭ�� �Ѿ��� ����Ʈ�κ��� �����Ѵ�.
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

    void FireSpecialType1()  //��ü ����(total_gap)�� �����س���
    {
        //1. ��Ŀ�� �ִ� ������ �������� ��´�.
        Vector3 anchor = new Vector3(total_gap * -0.5f, 1.2f, 0);

        //2. ��Ŀ�� ��ġ�κ��� �̵� ���� = ��ü ���� / (�Ѿ� ���� + 1)
        float term = total_gap / (bulletCount + 1);

        // 3. �Ѿ��� ������ŭ �ݺ��ؼ� ��Ŀ�� ��ġ���� �̵� ���ݸ�ŭ ������ ���� �Ѿ��� �����Ѵ�. 
        for(int i = 0; i < bulletCount; i++)
        {
            GameObject go = Instantiate(bulletFactory);
            go.transform.position = transform.position + anchor + new Vector3(term * (i+1), 0, 0); //���� ��ġ�� �������� �ؾ���!
        }
    }

    void FireSpecialType2() //�Ѿ� ���� ����(bullet_gap) ����
    {
        ////1. ��ü ����(range)�� ���̸� ���Ѵ�. 
        //float range = bullet_gap * (bulletCount - 1);

        ////2. ��Ŀ�� �ִ� ������ �������� ��´�.
        //Vector3 anchor = new Vector3(range * -0.5f, 1.2f, 0); //��ü ����(range)�� �ݹ� ������ ���� �������� anchor�� ����

        ////3. �Ѿ��� ������ŭ �ݺ��ؼ� ��Ŀ ��ġ���� �̵� ���ݸ�ŭ ������ ���� �Ѿ��� �����Ѵ�.
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
