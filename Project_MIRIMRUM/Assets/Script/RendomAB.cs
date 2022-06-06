using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendomAB : MonoBehaviour
{
    blic GameObject[] prefabs; //찍어낼 게임 오브젝트를 넣어요
                                 //배열로 만든 이유는 게임 오브젝트를
                                 //다양하게 찍어내기 위해서 입니다
    private BoxCollider area;    //박스콜라이더의 사이즈를 가져오기 위함
    public int count = 3;      //찍어낼 게임 오브젝트 갯수

    private List<GameObject> gameObject = new List<GameObject>();

    void Start()
    {
        area = GetComponent<BoxCollider>();

        for (int i = 0; i < count; ++i)//count 수 만큼 생성한다
        {
            Spawn();//생성 + 스폰위치를 포함하는 함수
        }

        area.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
