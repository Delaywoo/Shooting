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


    float finalSpeed = 0;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        finalSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()  //������ �ð��� �ѹ��� ������Ʈ�Ǵ°�
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

        transform.position += direction * moveSpeed * Time.deltaTime;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed = moveSpeed * 2;

        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            finalSpeed = moveSpeed;
        }

        // ���� Shiflt Ű���� ���� ���� �ٽ� ���� �ӵ���� ���ƿ´�.
        

        // �̹� �����ӿ� ������ ���������� �Ÿ��� ���Ѵ�.
        Vector3 arrivePos = direction * finalSpeed * Time.deltaTime;

        // ���� ��ġ���� ���� �������� ���̸� �߻��غ���.
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, arrivePos.magnitude))
        {

            if(hitInfo.distance < arrivePos.magnitude)
            {
                transform.position = hitInfo.point;
                transform.position -= direction * 0.5f;

            }
            
        }

        else
        {
            rb.velocity = direction * finalSpeed;

        }



        //�÷��̾��� ���� ��ǥ�� ����Ʈ ��ǥ�� ȯ���Ѵ�.
        //Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        //ȯ��� ����Ʈ ��ǥ�� 0~1 ������ ������ �����Ѵ�.
        //viewPos.x = Mathf.Clamp01(viewPos.x);
        //viewPos.y = Mathf.Clamp01(viewPos.y);


        //���� ����� ����Ʈ ��ǥ�� ���� ��ǥ�� ��ȯ�ؼ� �÷��̾� ���������� �����.
        //transform.position = Camera.main.ViewportToWorldPoint(viewPos);
        
        


    }
}
