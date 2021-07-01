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
}
