using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Texture2D border;
    public Rect borderPosition;

    public Texture2D bar;
    public Rect barPosition;

    public float horizontalDistance;
    //�������, �� ������� ����� ������� ������ Bar (��������� ��� ������ ������� Border)
    public float verticalDistance;
    //�������, �� ������� ����� ������� ���� Bar (��������� ��� ������ ������� Border)

    public float wigthBar;
    public float heightBar;

    public Fighter player;
    //� inspector ����������� ������

    public EnemyBehaviour target;
    public float healthPercentage;
    //���������� ������� �������� �������� 
    void Start()
    { 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.opponent != null)
        {
            target = player.opponent.GetComponent<EnemyBehaviour>();
            healthPercentage = (float) target.health / target.maxHealth;
            // ������� ������� �������� ( 50 / 100 = 50%)
        }
        else
        {
            target = null;
            healthPercentage = 0;
        }
    }

    private void OnGUI()
    {

        if (target != null && player.countDown > 0)
        {
            drawFrame();
            drawBar();
        } 
    }

    void drawFrame()
    {
        borderPosition.x = (Screen.width - borderPosition.width) / 2;
        float width = 0.26f;
        borderPosition.width = Screen.width * width;
        borderPosition.height = Screen.height * 0.04f;
        GUI.DrawTexture(borderPosition, border); // ���� ����� ������������ �������� �� ������
    }

    void drawBar()
    {
        //� Bar ������ �� �� �������, ��� � � Frame (border)
        barPosition.x = borderPosition.x + borderPosition.width * horizontalDistance;
        barPosition.y = borderPosition.y + borderPosition.height * verticalDistance;
        barPosition.width = borderPosition.width * wigthBar * healthPercentage;
        barPosition.height = borderPosition.height * heightBar;
        GUI.DrawTexture(barPosition, bar);

    }
}
