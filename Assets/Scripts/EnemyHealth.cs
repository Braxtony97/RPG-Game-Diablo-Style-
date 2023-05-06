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
    //процент, на который будем двигать вправо Bar (подгоняем под черную область Border)
    public float verticalDistance;
    //процент, на который будем двигать вниз Bar (подгоняем под черную область Border)

    public float wigthBar;
    public float heightBar;

    public Fighter player;
    //в inspector прикрепляем игрока

    public EnemyBehaviour target;
    public float healthPercentage;
    //показывает текущее значение здоровья 
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
            // покажет процент здоровья ( 50 / 100 = 50%)
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
        GUI.DrawTexture(borderPosition, border); // этот метод отрисовывает текстуры на экране
    }

    void drawBar()
    {
        //у Bar делаем ту же позицию, что и у Frame (border)
        barPosition.x = borderPosition.x + borderPosition.width * horizontalDistance;
        barPosition.y = borderPosition.y + borderPosition.height * verticalDistance;
        barPosition.width = borderPosition.width * wigthBar * healthPercentage;
        barPosition.height = borderPosition.height * heightBar;
        GUI.DrawTexture(barPosition, bar);

    }
}
