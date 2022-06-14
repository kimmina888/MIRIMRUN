using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpPower = 7;
    public float MoveSpeed = 5.0f;

    private float currentMoveSpeed;
    private float currentJumpPower;
    private bool slow;
    private float slowTime;
    private Rigidbody rigid;
    private bool IsJumping;
    private bool IsAlive;
    private Animator animator;
    private int direction = 0; //0 : ��, 1 : ����, 2: ��, 3 : �� 
    private Vector3 moveVec;
    private bool clear = false;

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

        currentJumpPower = slow ? JumpPower*0.8f : JumpPower;
        currentMoveSpeed = slow ? MoveSpeed*0.2f : MoveSpeed;
        
         
        Move();
        Jump();
        if (!IsAlive)
        {
            SceneManager.LoadScene("gameOver");
        }
        if (clear)
        {
            SceneManager.LoadScene("gameClear");
        }
    }

    void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * currentMoveSpeed * Time.deltaTime;
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
                rigid.AddForce(Vector3.up * currentJumpPower, ForceMode.Impulse);
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
        if (collision.gameObject.CompareTag("Clear"))
        {
            //Ŭ����! ���� �ð� ����, ��ŷ ȭ������ �̵�
            Debug.Log("hi");
            clear = true;
        }
    }

}
