using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendomAB : MonoBehaviour
{
    blic GameObject[] prefabs; //�� ���� ������Ʈ�� �־��
                                 //�迭�� ���� ������ ���� ������Ʈ��
                                 //�پ��ϰ� ���� ���ؼ� �Դϴ�
    private BoxCollider area;    //�ڽ��ݶ��̴��� ����� �������� ����
    public int count = 3;      //�� ���� ������Ʈ ����

    private List<GameObject> gameObject = new List<GameObject>();

    void Start()
    {
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; ++i)//count �� ��ŭ �����Ѵ�
        {
            Spawn();//���� + ������ġ�� �����ϴ� �Լ�
        }

        area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; ++i)
        {
            Spawn();//���� + ������ġ�� �����ϴ� �Լ�
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;
        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);
        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);

        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();//������ġ�Լ�

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }
}