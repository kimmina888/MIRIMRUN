using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type { Melee, Range};//Melee�� ����, Range�� ���Ÿ�
    public Type type;
    public int damage;
    public float rate; //���ݼӵ�
    public BoxCollider meleeArea;//���� ����
    public TrailRenderer trailEffect; //ȿ�� 
    public bool swingRunning = false;

    public void Use()
    {
        if (type == Type.Melee)
        {
            StopCoroutine("Swing"); //�ڷ�ƾ �۵� �ƿ� ����
            StartCoroutine("Swing");
        }
    }

    IEnumerator Swing()
    {
        swingRunning = true;
        //�ڷ�ƾ�� ���� ��ƾ�� Swing()�Լ��� ���� �����ϴ°�...

        //1
        //yield�� ����� ����. �ڷ�ƾ�� �� �� �̻� �� ���Եž��ϴ°�
        yield return new WaitForSeconds(0.1f); //0.1�� ���
        meleeArea.enabled = true; //Ȱ��ȭ
        trailEffect.enabled = true;

        //2
        yield return new WaitForSeconds(0.5f);
        meleeArea.enabled = false;

        //3
        yield return new WaitForSeconds(1.0f);
        trailEffect.enabled = false;

        swingRunning = false;
        //yield break;//�ڷ�ƾ Ż��
    }

}
