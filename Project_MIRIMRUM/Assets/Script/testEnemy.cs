using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemy : MonoBehaviour
{
    public float MoveSpeed = 5.0f;

    private Rigidbody rigid;
    private bool IsAlive;
    private Animator animator;
    private int direction = 0; //0 : ¾Õ, 1 : ¿À¸¥, 2: µÚ, 3 : ¿Þ 
    private Vector3 moveVec;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        IsAlive = true;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime);
        
        //animator.SetBool("run", moveVec != Vector3.zero);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsAlive = false;
        }
    }
}