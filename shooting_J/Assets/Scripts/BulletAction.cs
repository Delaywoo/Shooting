using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    //나는(총알은) 생성되면 그냥 위쪽으로 간다. 한없이.
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

    //충돌 처리 콜백 함수
    private void OnCollisionEnter(Collision col)
    {
        //부딪힌 대상이 enemy라면 상대방을 제거하고, 나도 제거한다.
        if(col.gameObject.tag == "Enemy")
        {
            //폭발 이펙트 오브젝트를 생성한 뒤 이펙트를 실행한다.
            //GameObject go = Instantiate(explosionPrefab, col.transform.position, Quaternion.identity);
            //ParticleSystem ps = go.GetComponentInChildren<ParticleSystem>();
            //ps.Play();


            //범위형 폭탄(특정 범위 내의 적들을 모두 폭발해버리기)            
            //Collider[] cols = Physics.OverlapSphere(transform.position, 6.0f, 1 << 8);

            //방식1
            //for (int i = 0; i < cols.Length; i++)
            //{
            //    Destroy(cols[i].gameObject);

            //}

            //방식2
            //foreach(Collider enemy in cols)
            //{
            //    Destroy(enemy);
            //}


            //방식3
            //int i = 0;
            //while(i < cols.leng)

            Destroy(col.gameObject);
            GameManager.gm.currentScore++;

            Destroy(gameObject);


        }
        
        
        
        
    }


}
