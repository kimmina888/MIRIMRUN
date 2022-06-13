using UnityEngine;

public class testEnemy : MonoBehaviour
{
    public float MoveSpeed = 60.0f;

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
        Move();
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
        if (collision.gameObject.CompareTag("Player"))
        {
            IsAlive = false;
        }
    }
}