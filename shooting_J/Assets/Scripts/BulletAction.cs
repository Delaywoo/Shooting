using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    //����(�Ѿ���) �����Ǹ� �׳� �������� ����. �Ѿ���.
    public float bulletspeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * bulletspeed * Time.deltaTime;
    }

    //�浹 ó�� �ݹ� �Լ�
    private void OnCollisionEnter(Collision col)
    {
        //�ε��� ����� enemy��� ������ �����ϰ�, ���� �����Ѵ�.
        if(col.gameObject.tag == "Enemy")
        {
            //���� ����Ʈ ������Ʈ�� ������ �� ����Ʈ�� �����Ѵ�.
            //GameObject go = Instantiate(explosionPrefab, col.transform.position, Quaternion.identity);
            //ParticleSystem ps = go.GetComponentInChildren<ParticleSystem>();
            //ps.Play();


            //������ ��ź(Ư�� ���� ���� ������ ��� �����ع�����)            
            //Collider[] cols = Physics.OverlapSphere(transform.position, 6.0f, 1 << 8);

            //���1
            //for (int i = 0; i < cols.Length; i++)
            //{
            //    Destroy(cols[i].gameObject);

            //}

            //���2
            //foreach(Collider enemy in cols)
            //{
            //    Destroy(enemy);
            //}


            //���3
            //int i = 0;
            //while(i < cols.leng)

            Destroy(col.gameObject);
            GameManager.gm.currentScore++;

            Destroy(gameObject);


        }
        
        
        
        
    }


}
