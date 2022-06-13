using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpPower = 7;
    public float MoveSpeed = 5.0f;


    private bool slow;
    private float slowTime;
    private Rigidbody rigid;
    private bool IsJumping;
    private bool IsAlive;
    private Animator animator;
    private int direction = 0; //0 : ��, 1 : ����, 2: ��, 3 : �� 
    private Vector3 moveVec;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity = new Vector3(0, -10f, 0);
        IsJumping = false;
        IsAlive = true;
    }

    void Update()
    {
        if(slow && slowTime >= 5)
        {
            //10�ʰ� �Ѿ�� slow ����
            slow = false;
            slowTime = 0;
        }
        else
        {
            slowTime += Time.deltaTime;
        }

        JumpPower = slow ? 4 : 5;
        MoveSpeed = slow ? 0.8f : 5.0f;
        
         
        Move();
        Jump();
        if (!IsAlive)
        {
            Debug.Log("hi");
            SceneManager.LoadScene("gameOver");
        }
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * MoveSpeed * Time.deltaTime;
        animator.SetBool("run", moveVec!=Vector3.zero);

        transform.LookAt(transform.position + moveVec);
    }
  
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsJumping)
            {
                IsJumping = true;
                //ForceMode.Impulse : ª�� �ð��� ���� �߰�
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("IsAlive");
            IsAlive = false;
        }
        if (collision.gameObject.CompareTag("Hurdle"))
        {
            slow = true; //��ֹ��� ������ ����������
        }
    }

}
