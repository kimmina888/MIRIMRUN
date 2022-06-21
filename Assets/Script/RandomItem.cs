using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPosition = transform.position;
        startPosition.x = Random.Range(-3.1f, 1.18f);
        startPosition.y = Random.Range(2.54f, 2.9f);
        startPosition.z = Random.Range(4.5f, 215.5f);
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
