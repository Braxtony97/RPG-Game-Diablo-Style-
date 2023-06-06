using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    //нам нужно набрать 100 очков опыта что бы поднимать левел
    
    public int level;
    public int exp;
    public Fighter player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelUp();
    }

    void levelUp()
    {
        if (exp >= Mathf.Pow(level, 2) + 100)
        {
            exp = exp - (int)(Mathf.Pow(level, 2) + 100);
            level = level + 1;
            levelEffect();
            //exp после каждого левел апа должен обнуляться
        }
    }

    void levelEffect()
    {

            player.Rename = player.Rename + 4;
            player.MaxHealth = player.MaxHealth + 20;
            player.Health = player.MaxHealth;
         
    }
}
