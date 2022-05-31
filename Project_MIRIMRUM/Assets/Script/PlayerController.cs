using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpPower = 7;
    public float MoveSpeed = 5.0f;

    private Rigidbody rigid;
    private bool IsJumping;
    private bool IsAlive;
    private Animator animator;
    private int direction = 0; //0 : ¾Õ, 1 : ¿À¸¥, 2: µÚ, 3 : ¿Þ 
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
                //ForceMode.Impulse : ÂªÀº ½Ã°£¿¡ ÈûÀ» Ãß°¡
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
    }

}
