using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public Vector3 launchDirection;                         //�߻� ���� 

    private void FixedUpdate()
    {
        float moveAmount = 10 * Time.fixedDeltaTime;             //�̵� �ӵ� ����
        transform.Translate(launchDirection * moveAmount);      //Translate �� �̵� 
    }
    private void OnCollisionEnter(Collision collision)          //�浹�� �Ͼ�� ���
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Object")                //Tag ���� ������Ʈ �� ��� 
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Monster")                //Tag ���� ������Ʈ �� ��� 
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Monster>().Damaged(1);
        }

    }
}
