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
    void Start()
    {
        anim = GetComponent<Animation>();      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (opponent != null)
            {
                anim.Play("attack");
                transform.LookAt(opponent.transform.position);
                ClickToMove.attack = true;
            }
        }
        if (!anim.IsPlaying("attack")){
            ClickToMove.attack = false;
            impacted = false;
        }
      
        impact();
    }

    void impact()
    {
        if (opponent != null && anim.IsPlaying("attack") && !impacted)
        {
            if (anim["attack"].time > anim["attack"].length * impactTime)
            {
                opponent.GetComponent<EnemyBehaviour>().GetHit(damage);
                impacted = true;
            }
        }
    }

}

