using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Fighter : MonoBehaviour
{
    public GameObject opponent;
    private Animation anim;
    public int damage;
    public double impactTime;
    private bool impacted;
    public float range;
    public int health;

    bool starterd;
    bool ended;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health + " Player"); 
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (opponent != null)
            {
                anim.Play("attack");
                transform.LookAt(opponent.transform.position);
                ClickToMove.attack = true; // при одиночном нажатии на space - не будет ударять (только если держать)
                // Нажали space - произошел удар, при этом в классе ClickToMove мы остановились (начинает играть анимация idle) - ведь мы не нажимает ЛКМ
            }
        }
        if (anim["attack"].time > 0.9 * anim["attack"].length){
            ClickToMove.attack = false; // для того, что бы после удара можно было управлять персонажем дальше
            impacted = false;
        }
        die();
        impact();
    }

    void impact()
    {
        if (opponent != null && anim.IsPlaying("attack") && !impacted)
        {
            if ((anim["attack"].time > anim["attack"].length * impactTime) &&  (anim["attack"].time < anim["attack"].length * 0.9))
            {
                if (inRange())
                {
                    
                    opponent.GetComponent<EnemyBehaviour>().GetHit(damage);
                    impacted = true;
                } 
            }
        }
    }

    bool inRange()
    {
        return Vector3.Distance(transform.position, opponent.transform.position) <= range;
    }

    public void getHit(int damage)
    {
        health = health - damage;
        if (health < 0)
        {
            health = 0;
        }
        //если не добавить блок с if, то здоровье будет уменьшаться дальше ( в минус)
       
    } 
    public bool isDead()
    {
        return (health <= 0);
    }
    void die()
    {
        if (isDead() && !ended)
        // если у Игрока закончилось здоровье
        {
            if (!starterd)
            {
                anim.Play("die");
                
                starterd = true;
            } 
            if (starterd && anim.IsPlaying("die"))
            {
                Debug.Log("Dead");
                ended = true;
            }
        }
    }
}

