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
    public GameObject particleEffects;
    public bool opponentBased;

    public int projectile;

    public Texture2D picture;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && !player.specialAttack)
        /*если много раз нажимать 1 - то player будет начинать атаку снова
        поэтому в условие добавляем !player.specialAttack */
        {
            player.resetAttackFunction();
            player.specialAttack = true;
            inAction = true;
            //не вызовется атака простая

        } 
        if (inAction)
        {
            if (player.attackFunction(stunTime, damagePercentage, key, particleEffects, projectile, opponentBased))
            {
                //продолжаем
            }
            else
            {
                inAction = false;
                //если player.attackFunction(stunTime, damagePercentage, key завершилась (в блоке завершения атаки) = false
                //то и тут inAction = false (что бы не вызывалась специальная атака снова (пока сами не вызовем))
            }
        }

    }
}
