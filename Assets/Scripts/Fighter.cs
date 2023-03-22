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

    public bool inAction;

    bool starterd;
    bool ended;

    public int maxHealth;

    public float combatEscapeTime;

    public float countDown;
    //когда ударим врага, пойдет отсчет 
    //когда дойдет до 0, выйдем из комбат

    public bool specialAttack;
    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !specialAttack)
        {
            inAction = true;
        }
        if (inAction)
        {
            if (attackFunction(0, 1, KeyCode.Space, null, 0, true))
            {
                //проигрывается attackFunction(0, 1, KeyCode.Space)
                //когда он станет fasle - идем ниже
            }
            else
            {
                inAction = false;
            }
        }
        die();

    }

    public bool attackFunction(int stunSecond, double scaleDamage, KeyCode key, GameObject particleEffects, int projectile, bool opponentBased)
    {

        {
            if (opponentBased)
            //если враг true, то  атакуем врага
            {
                if (Input.GetKey(key) && inRange())
                {
                    anim.Play("attack");
                    ClickToMove.attack = true;
                    if (opponent != null)
                    {
                        transform.LookAt(opponent.transform.position);
                    }
                }
            }
            else
            {
                //если врага нет, то и условие inRange() не нужно
                if (Input.GetKey(key))
                {
                    anim.Play("attack");
                    ClickToMove.attack = true;

                        transform.LookAt(ClickToMove.cursorPosition);
                }
            }
        }

        if (anim["attack"].time > 0.9 * anim["attack"].length)
        {
            ClickToMove.attack = false; // для того, что бы после удара можно было управлять персонажем дальше
            impacted = false;
            if (specialAttack)
            {
                specialAttack = false;
            }
            //если этого блока не будет, то после того, как нажмем 1 для оглушения, то 
            //потом не сможем использовать простую атаку
            return false;
            // Когда атака завершается - false, 
        }
        impact(stunSecond, scaleDamage, particleEffects, projectile, opponentBased);
        //играется атака и вызывается метод impact
        return true;
        //вернет true, если мы в атакуем еще (inAction (specialAttack))
    }

    public void resetAttackFunction()
    {
        ClickToMove.attack = false;
        impacted = false;
        anim.Stop("attack");

    }

    void impact(int stunSecond, double scaleDamage, GameObject particleEffects, int projectile, bool opponentBased)
    {
        if ((!opponentBased || opponent != null) && anim.IsPlaying("attack") && !impacted)
        {
            if ((anim["attack"].time > anim["attack"].length * impactTime) && (anim["attack"].time < anim["attack"].length * 0.9))
            {
                {
                    countDown = combatEscapeTime;
                    CancelInvoke("combatEscapeCountDown");
                    InvokeRepeating("combatEscapeCountDown", 0, 1);
                    opponent.GetComponent<EnemyBehaviour>().GetHit(damage * (int)scaleDamage);
                    opponent.GetComponent<EnemyBehaviour>().getStun(stunSecond);
                    Quaternion rot = transform.rotation;
                    rot.x = 0;
                    rot.z = 0;
                    if (projectile > 0 )
                    {
                        //project projectiles
                        Instantiate(Resources.Load("Projectile"), new Vector3(transform.position.x, transform.position.y * 2.5f, transform.position.z), rot);
                    }
                    //Instantiate(Resources.Load("attackOne"), opponent.transform.position, Quaternion.identity);
                    if (particleEffects != null)
                    {
                        Instantiate(particleEffects, new Vector3(opponent.transform.position.x, opponent.transform.position.y * 2.5f, opponent.transform.position.z), Quaternion.identity);
                    } 
                    impacted = true;
                }
            }
        }
    }

    void combatEscapeCountDown()
    {
        countDown = countDown - 1;
        if (countDown == 0)
        {
            CancelInvoke("combatEscapeCountDown");
            //перестает вызывать метод 
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
