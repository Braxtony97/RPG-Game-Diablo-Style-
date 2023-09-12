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
        if (Input.GetKeyDown(key) && !player.SpecialAttack)
        /*���� ����� ��� �������� 1 - �� _playerTransform ����� �������� ����� �����
        ������� � ������� ��������� !_playerTransform.specialAttack */
        {
            player.resetAttackFunction();
            player.SpecialAttack = true;
            inAction = true;
            //�� ��������� ����� �������

        } 
        if (inAction)
        {
            if (player.attackFunction(stunTime, damagePercentage, key, particleEffects, projectile, opponentBased))
            {
                //����������
            }
            else
            {
                inAction = false;
                //���� _playerTransform.attackFunction(stunTime, damagePercentage, key ����������� (� ����� ���������� �����) = false
                //�� � ��� inAction = false (��� �� �� ���������� ����������� ����� ����� (���� ���� �� �������))
            }
        }

    }
}
