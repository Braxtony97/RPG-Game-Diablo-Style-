using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public static int assigner;
    // у static такое св-во?
    public int id;
    //id врага
    
    public Transform player;
    public float speed;
    public CharacterController controller;
    public float range;
    private Animation anim;

    public LevelSystem levelSystem;

    public double impactTime = 0.33;

    public int maxHealth;
    public int health;
    bool impacted;
    private Fighter opponent;
    public int damage;

    private int stunTime;
    //время оглушения 


    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animation>();
        opponent = player.GetComponent<Fighter>();
        levelSystem = player.GetComponent<LevelSystem>();
        assignId();
        int dataBaseHealth = DataBase.readEnemyHealth(id);
        if (dataBaseHealth == -1)
        {

        }
        else
        {
            health = DataBase.readEnemyHealth(id);
        }

    }

    void assignId()
    {
        this.id = assigner;
        assigner ++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead())
        {
            if (stunTime <= 0)
            //если враг не оглушен, то он атакует
            {
                if (!inRange())
                {
                    chase();
                }
                else
                {
                    //_animation.CrossFade("Idle");
                    anim.Play("Attack");
                    attack();
                    if (anim["Attack"].time > anim["Attack"].length * 0.9)
                    //что бы атака вызывалась еще раз только после 90% продолжительности атаки
                    //но будет вызываться каждый кадр до 100% продолжительности
                    //поэтому в самом методе Attack() нужно прописать условие
                    //что наносить урон только от impactTime до 90%
                    {
                        impacted = false;
                        //если (impacted = false;), то метод Attack() 
                        //вызовется только 1 раз
                    }
                }
            }
            else
            {

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

        DataBase.saveEnemyHealth(id, health);
    }

    public void getStun(int seconds)
    //в метод будет передавать время оглушения (у player в скрипте
    //fighter будем вызывать этот метод
    {
        CancelInvoke("stunCountDown");
        //перезапускаем stun 
        stunTime = seconds;
        InvokeRepeating("stunCountDown", 0f, 1f);
        //повторение метода каждую 1f секунду с задержкой в 0f,
    }

    void stunCountDown()
    {
        stunTime = stunTime - 1;
        if (stunTime == 0)
        {
            CancelInvoke("stunCountDown");
        }
    }

    void attack()
    {
        if (anim.IsPlaying("Attack") && !impacted)
        //если анимация Attack проигрывается И impacted = false;, то выполняется тело
        {
            if (anim["Attack"].time > anim["Attack"].length * impactTime && anim["Attack"].time < anim["Attack"].length * 0.9)
            // если время атаки больше, чем продолжительность атаки (100%) * импактТайм(время атаки) (0.33) 
            // И время атаки меньше, чем 90% продолжительности атаки 
            {
                opponent.getHit(damage);
                // у opponent вызываем метод getHit и передаем ему damage
                impacted = true;
                //если не поставить (impacted = true;) - то метод Attack() будет 
                //вызываться каждый кадр (в Update())

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
            levelSystem.exp = levelSystem.exp + 100;
            Instantiate(Resources.Load("dieSkull"), transform.position, Quaternion.identity);
            Destroy(gameObject);  
        }
    }
    bool isDead()
    {
        return (health <= 0);
    }
    void chase()
    {
        //Quaternion newRotation = Quaternion.LookRotation(transform._position - player._position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 10 * Time.deltaTime);
        transform.LookAt(player.position);
        controller.SimpleMove(transform.forward * speed);
        anim.CrossFade("Run");
    }

    void OnMouseOver()
    {
        player.GetComponent<Fighter>().Opponent = this.gameObject;
        //Debug.Log("Opponent = Enemy");
    }


}
