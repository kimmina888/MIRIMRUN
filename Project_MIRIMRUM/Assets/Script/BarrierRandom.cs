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

            // �ҷ��� ������Ʈ�� �����ϰ� ������ ��ǥ������ ��ġ�� �ű��.
            Barrier.transform.position = new Vector3(newX, newY, newZ);

    }
}
