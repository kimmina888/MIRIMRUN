using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour
{
    [SerializeField][Range(0f, 100f)] private float speed = 10f;
    [SerializeField][Range(0f, 1f)] private float length = 1f;

    private float runningTime = 0f;
    private float yPos = 0f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        runningTime += Time.deltaTime * speed*1000;
        yPos = Mathf.Sin(runningTime) * length/100;
        Debug.Log(yPos);
        this.transform.position = new Vector3(transform.position.x, transform.position.y+ yPos, transform.position.z);
    }
}
