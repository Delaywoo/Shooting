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
}
