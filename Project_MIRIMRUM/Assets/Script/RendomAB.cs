using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendomAB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        let z = Random.range(-5, 5);
        let x = Random.range(-5, 5);
        let y = 0.5;
        GameObject enemy = (GameObject)Instantiate(obj, new Vector3(x, y, z),Quaternion.identity);
    }
}
