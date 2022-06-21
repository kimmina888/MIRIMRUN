using System.Collections;
using UnityEngine;

public class testEnemy : MonoBehaviour
{
    public float MoveSpeed = 60.0f;
    public PlayerController player;
    
    private Rigidbody rigid;
    private bool IsAlive;
    private Animator animator;
    private int direction = 0; //0 : 앞, 1 : 오른, 2: 뒤, 3 : 왼 
    private Vector3 moveVec;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        IsAlive = true;
        Vector3 startPosition = transform.position;
        startPosition.x = Random.Range(-3.1f, 1.18f);
        startPosition.y = Random.Range(2.54f, 4.53f);
        startPosition.z = Random.Range(4.5f, 215.5f);
        transform.position = startPosition;
    }

    void Update()
    {
        if (IsAlive)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 nextPosition = transform.position;
        nextPosition.z -= MoveSpeed * Time.deltaTime;
        transform.position = nextPosition;
        if(transform.position.z <= 0.3f)
        {
            //앞에 다 오면 다시 새로운 위치를 할당...,,,,,,
            Vector3 startPosition = transform.position;
            startPosition.x = Random.Range(-3.1f, 1.18f);
            startPosition.y = Random.Range(2.54f, 5.83f);
            startPosition.z = 215.5f;
            transform.position = startPosition;
        }
        //animator.SetBool("run", moveVec != Vector3.zero);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.transform.Find("Root/center/Hips/Spine/Chest/Upper_Chest/Clavicle_R/Upper_Arm_R/Lower_Arm_R/Hand_R/WeaponPoint_GreatSword/Prop_03_greatsword").GetComponent<BoxCollider>().enabled)
        {
            StartCoroutine("Die");
            Debug.Log("dd");
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        //EffectManager.PlayEffect(transform.position); //이펙트,,
        this.gameObject.active = false;
        player.itemEffectType = PlayerController.ItemEffectType.Fast;
        player.itemEffect = true;
 
    }
}