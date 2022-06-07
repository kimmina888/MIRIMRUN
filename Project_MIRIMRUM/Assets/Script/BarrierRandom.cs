using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierRandom : MonoBehaviour
{
    public GameObject Barrier;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            float newX = Random.Range(-10f, 10f), newY = Random.Range(-50f, 50f), newZ = Random.Range(-100f, 100f);

            // 불러온 오브젝트를 랜덤하게 생성한 좌표값으로 위치를 옮긴다.
            Barrier.transform.position = new Vector3(newX, newY, newZ);

    }
}
