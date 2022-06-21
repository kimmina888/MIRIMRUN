using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpPower = 7;
    public float MoveSpeed = 5.0f;

    public enum ItemEffectType{
        Basic,
        Normal,
        Slow,
        Fast,
        Big,
        Small
    }

    float currentMoveSpeed;
    float currentJumpPower;
    bool slow;
    float slowTime;
    public bool itemEffect;
    public ItemEffectType itemEffectType = ItemEffectType.Normal;
    float itemEffectTime;
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
        itemEffect = false;
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

        if (itemEffect && itemEffectTime >= 5)
        {
            itemEffect = false;
            itemEffectTime = 0;
            itemEffectType = ItemEffectType.Normal;
        }
        else
        {
            itemEffectTime += Time.deltaTime;
        }

        currentJumpPower = slow ? JumpPower * 0.8f : JumpPower;
        currentMoveSpeed = slow ? MoveSpeed * 0.2f : MoveSpeed;

        switch (itemEffectType)
        {
            case ItemEffectType.Normal:
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case ItemEffectType.Slow:
                currentJumpPower = JumpPower * 0.8f;
                currentMoveSpeed = MoveSpeed * 0.2f;
                break;
            case ItemEffectType.Fast:
                currentJumpPower = JumpPower * 1.0f;
                currentMoveSpeed = MoveSpeed * 1.2f;
                break;
            case ItemEffectType.Big: 
                transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                break;
            case ItemEffectType.Small:
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                break;
        }

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
            if (SceneManager.GetActiveScene().Equals("school_hard"))
            {
                SceneManager.LoadScene("gameClearH");
            }
            else
            {
                SceneManager.LoadScene("gameClearN");
            }
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
            clear = true;
        }
        if (collision.gameObject.CompareTag("GameOver"))
        {
            IsAlive = false;
        }
        if (collision.gameObject.CompareTag("RandomItem"))
        {
            //아이템을 먹음. 랜덤으로 효과 적용
            //ItemEffectType는 index가 0부터 시작

            itemEffectType = (ItemEffectType)Random.Range(1, 5); 
            itemEffect = true;
            collision.gameObject.SetActive(false);
        }
    }

}
