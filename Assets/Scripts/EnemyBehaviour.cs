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
                //что бы атака вызывалась еще раз только после 90% продолжительности атаки
                //но будет вызыватьс€ каждый кадр до 100% продолжительности
                //поэтому в самом методе attack() нужно прописать условие
                //что наносить урон только от impactTime до 90%
                {
                    impacted = false;
                    //если (impacted = false;), то метод attack() 
                    //вызоветс€ только 1 раз
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
        //если анимаци€ attack проигрываетс€ » impacted = false;, то выполн€етс€ тело
        {
            if (anim["attack"].time > anim["attack"].length * impactTime && anim["attack"].time < anim["attack"].length * 0.9)
            // если врем€ атаки больше, чем продолжительность атаки (100%) * импакт“айм(врем€ атаки) (0.33) 
            // » врем€ атаки меньше, чем 90% продолжительности атаки 
            {
                    opponent.getHit(damage);
                    // у opponent вызываем метод getHit и передаем ему damage
                    impacted = true;
                    //если не поставить (impacted = true;) - то метод attack() будет 
                    //вызыватьс€ каждый кадр (в Update())
                
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
