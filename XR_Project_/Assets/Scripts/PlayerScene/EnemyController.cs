using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;          //�̵� �ӵ� 
    public float rotationSpeed = 1.0f;  //��ž ȸ�� �ӵ�
    public GameObject bulletPrefab;     //�Ѿ�������
    public GameObject EnemyPivot;       //�� ��ž �Ǻ�
    public Transform firePoint;         //�߻� ��ġ
    public float fireRate = 1f;         //�߻� �ӵ� 

    private Rigidbody rb;
    private Transform player;

    private float NextFireTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                 //rb�� ���� RigidBody �Է�
        player = GameObject.FindGameObjectWithTag("Player").transform;              //Player Tag �� ������ �ִ� ������Ʈ transform �� �Է�
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            if (Vector3.Distance(player.position, transform.position) > 5.0f)
            {
                Vector3 direction = (player.position - transform.position).normalized;      //�̵� ���⼺ (�÷��̾�� ��)
                rb.MovePosition(transform.position + direction * speed * Time.deltaTime);   //���⼺ ���Ȱ� Rigidbody�� �ݿ�
            }

            //��ž ȸ�� 
            Vector3 targetDirection = (player.position - EnemyPivot.transform.position).normalized; //��ž�� ���⼺ ��� 
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            EnemyPivot.transform.rotation = Quaternion.Lerp(EnemyPivot.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); //���� ȸ������ �ݿ�

            if (Time.time > NextFireTime)
            {
                NextFireTime = Time.time + 1f / fireRate;           //�ð���� ��� Ƚ��
                GameObject temp = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                temp.GetComponent<ProjectileMove>().launchDirection = firePoint.localRotation * Vector3.forward;        //�߻����� �������ִ� ����
                temp.GetComponent<ProjectileMove>().projectileType = ProjectileMove.PROJECTILETYPE.MONSTER;             //�߻�ü Ÿ�� ���� 
                Destroy(temp, 10.0f);                   //10���Ŀ� ������ �߻�ä ����
            }
        }
      
    }
}
