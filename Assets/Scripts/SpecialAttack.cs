using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{

    public Fighter player;
    public KeyCode key;
    public double damagePercentage;
    public int stunTime;
    public bool inAction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key) && !player.specialAttack)
        {
            //this.GetComponent<Fighter>().resetAttackFunction();
            player.resetAttackFunction();
            player.specialAttack = true;
            //не вызовется атака простая

        } 

        player.attackFunction(stunTime, damagePercentage, key);
    }
}
