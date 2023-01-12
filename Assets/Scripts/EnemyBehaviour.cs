using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;
    public float speed;
    public CharacterController controller;
    public float range;
    private Animation anim;
    public int health = 100;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange())
        {
            chase();
        }
        else
        {
            anim.CrossFade("idle");
        }
        Debug.Log(health);
    }

    public void GetHit(int damage)
    {
        health = health - damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }

    bool inRange()
    {
        return (Vector3.Distance(transform.position, player.position) < range);
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
