using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // ������� �Է��� �޾Ƽ� ���� �Ǵ� �¿�� �̵��� �ϰ� �ʹ�.
    // ������� �Է�: �¿� ȭ��ǥ Ű, ���� ȭ��ǥ Ű, WASD Ű
    // �̵� �ʿ� ���: �ӵ�(����+�ӷ�), �ð�
    // A-B : B�� A�� ���ϴ� ����

    public float moveSpeed = 0.1f;
    float shiftspeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    print("���� �ϰ� ���� ȭ��ǥ Ű�� ���� ���� �˰� �ִ� ..");
        //}

        float h = Input.GetAxis("Horizontal");        //input manager���� ����ϰ��� �ϴ� name ����
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, v, 0);  //0: z���� �������δ� �̵���Ű�� �ʰڴٴ� ���� �ǹ�, ���� �ȵ�� �ִ°� �ƴ�!
        direction.Normalize(); // normalize(����ȭ) �Լ�

        // direction�� ������ ������ �̵��ϰ� �ʹ�.
        // p = p0 + vt

        // ���� Shift Ű�� ���� ������ ������ �ӵ��� 2��� �����Ѵ�.


        shiftspeed = moveSpeed ;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftspeed = moveSpeed * 2;

        }

        // ���� Shiflt Ű���� ���� ���� �ٽ� ���� �ӵ���� ���ƿ´�.
        transform.position += direction * shiftspeed * Time.deltaTime;
        
        


    }
}
