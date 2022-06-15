using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range};//Melee은 근접, Range는 원거리
    public Type type;
    public int damage;
    public float rate; //공격속도
    public BoxCollider meleeArea;//범위 지정
    public TrailRenderer trailEffect; //효과 
    public bool swingRunning = false;

    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing"); //코루틴 작동 아예 중지
            StartCoroutine("Swing");
        }
    }

    IEnumerator Swing()
    {
        swingRunning = true;
        //코루틴은 메인 루틴과 Swing()함수를 같이 실행하는것...

        //1
        //yield는 결과를 낸다. 코루틴에 한 개 이상ㄴ 꼭 포함돼야하는것
        yield return new WaitForSeconds(0.1f); //0.1초 대기
        meleeArea.enabled = true; //활성화
        trailEffect.enabled = true;

        //2
        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = false;

        //3
        yield return new WaitForSeconds(1.0f);
        trailEffect.enabled = false;

        swingRunning = false;
        //yield break;//코루틴 탈출
    }

}
