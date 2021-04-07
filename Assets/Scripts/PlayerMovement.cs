using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Singleton<PlayerMovement>
{
    public CharacterController controller; 
    public Transform player;
    private Vector3 movement;
    private float speed; 
    public bool isIdle = true; 
    EnemyManager enemyManager;  

    [HideInInspector]
    public GameObject nearestEnemy; 

    private void Start()
    {
        if (enemyManager == null)
        {
            enemyManager = EnemyManager.GetInstance();
        }

        speed = gameObject.GetComponent<TargetSelector>().GetSpeed();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical"); 

        //�������� ������ �������� ����� ���������
        movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);

        //��������� ���� �� ������ ��������
        if (movement.magnitude != 0)
        {
            //������� ������ � ������� �������� � ������� � ��������� ���������
            transform.rotation = Quaternion.LookRotation(movement); 
            controller.Move(movement * speed * Time.deltaTime);
            isIdle = false;
        }
        else
        { 
            isIdle = true;  
        } 
    }

    public Vector3 GetMoveDirection()
    {
        //�������� ������ ��������
        return movement;
    }
}
