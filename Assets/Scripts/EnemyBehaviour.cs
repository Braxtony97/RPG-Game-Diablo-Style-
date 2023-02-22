using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;
    public float speed;
    public CharacterController controller;
    public float range;
    private Animation anim;

    public double impactTime = 0.33;

    public int maxHealth;
    public int health;
    bool impacted;
    private Fighter opponent;
    public int damage;


    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animation>();
        opponent = player.GetComponent<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead())
        {
            if (!inRange())
            {
                chase();
            }
            else
            {
                //anim.CrossFade("idle");
                anim.Play("attack");
                attack();
                if (anim["attack"].time > anim["attack"].length * 0.9)
                //��� �� ����� ���������� ��� ��� ������ ����� 90% ����������������� �����
                //�� ����� ���������� ������ ���� �� 100% �����������������
                //������� � ����� ������ attack() ����� ��������� �������
                //��� �������� ���� ������ �� impactTime �� 90%
                {
                    impacted = false;
                    //���� (impacted = false;), �� ����� attack() 
                    //��������� ������ 1 ���
                }
            }
        }
        else
        {
            dieMethod();
        }
    }

    public void GetHit(int damage)
    {
        health = health - damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    void attack()
    {
        if (anim.IsPlaying("attack") && !impacted)
        //���� �������� attack ������������� � impacted = false;, �� ����������� ����
        {
            if (anim["attack"].time > anim["attack"].length * impactTime && anim["attack"].time < anim["attack"].length * 0.9)
            // ���� ����� ����� ������, ��� ����������������� ����� (100%) * ����������(����� �����) (0.33) 
            // � ����� ����� ������, ��� 90% ����������������� ����� 
            {
                    opponent.getHit(damage);
                    // � opponent �������� ����� getHit � �������� ��� damage
                    impacted = true;
                    //���� �� ��������� (impacted = true;) - �� ����� attack() ����� 
                    //���������� ������ ���� (� Update())
                
            }

        }
    }
    bool inRange()
    {
        return (Vector3.Distance(transform.position, player.position) < range);
    }
    void dieMethod()
    {
        anim["die"].wrapMode = WrapMode.ClampForever;
        anim.Play("die");
        if (anim["die"].time > anim["die"].length * 0.9)
        {
            Destroy(gameObject);
        }
    }
    bool isDead()
    {
        return (health <= 0) ;
    }
    void chase()
    {
        //Quaternion newRotation = Quaternion.LookRotation(transform.position - player.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10 * Time.deltaTime);
        transform.LookAt(player.position);
        controller.SimpleMove(transform.forward * speed);
        anim.CrossFade("run");
    }

    void OnMouseOver()
    {
        player.GetComponent<Fighter>().opponent = this.gameObject;
        //Debug.Log("Opponent = Enemy");
    }


}
