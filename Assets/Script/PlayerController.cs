using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpPower = 7;
    public float MoveSpeed = 5.0f;

    float currentMoveSpeed;
    float currentJumpPower;
    bool slow;
    float slowTime;
    Rigidbody rigid;
    bool IsJumping;
    bool IsAlive;
    Animator animator;
    int direction = 0; //0 : ��, 1 : ����, 2: ��, 3 : �� 
    Vector3 moveVec;
    bool clear = false;
    bool isDamage; //무적 타임

    bool fDown; //
    bool isFireReady; //준비 완료
    float fireDelay; //공격 딜레이

    public Weapon weapon;

    //key
    float hAxis;
    float vAxis;

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
            slow = false;
            slowTime = 0;
        }
        else
        {
            slowTime += Time.deltaTime;
        }

        currentJumpPower = slow ? JumpPower*0.8f : JumpPower;
        currentMoveSpeed = slow ? MoveSpeed*0.2f : MoveSpeed;
        
        GetInput();
        Attak();
        if (!isDamage)
        {
            Move();
            Jump();
        }
        if (!IsAlive)
        {
            SceneManager.LoadScene("gameOver");
        }
        if (clear)
        {
            Ranking.clearTime = Timer.time;
            SceneManager.LoadScene("gameClear");
        }
    }

    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        fDown = Input.GetButtonDown("Fire1"); //z
    }

    void Attak()
    {
        if (weapon == null)
            return;
        fireDelay += Time.deltaTime;
        isFireReady = weapon.rate < fireDelay; //공격 가능한지

        if(fDown && isFireReady)
        {
            weapon.Use(); //무기사용
            animator.SetTrigger("doSwing");
            fireDelay = 0;
        }

    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * currentMoveSpeed * Time.deltaTime;
        animator.SetBool("run", moveVec!=Vector3.zero);

        transform.LookAt(transform.position + moveVec);
    }
  
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y < 3)
            {
                IsJumping = true;
                rigid.AddForce(Vector3.up * currentJumpPower, ForceMode.Impulse);
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator OnDamage()
    {
        isDamage = true;

        animator.SetTrigger("stop");
        yield return new WaitForSeconds(1f);

        isDamage = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
        if (collision.gameObject.CompareTag("Enemy") && !weapon.swingRunning)//weapon.swingRunning은 공격중
        {
            if(!isDamage)
                StartCoroutine("OnDamage");
        }
        if (collision.gameObject.CompareTag("Hurdle"))
        {
            slow = true; //��ֹ��� ������ ����������
        }
        if (collision.gameObject.CompareTag("Clear"))
        {
            Debug.Log("hi");
            clear = true;
        }
        if (collision.gameObject.CompareTag("GameOver"))
        {
            IsAlive = false;
        }
    }

}
