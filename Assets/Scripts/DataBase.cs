using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    int interval = 120;
    //с каким интервалом сохраняться будет
    int count;
    public EnemyBehaviour target;

    void Start()
    {
        
    }

    void Update()
    {
        ResetData();
        if (count == interval)
        {
            //save
            savePlayerPosition();
            count = 0;
        }
        count++;

    }
    void savePlayerPosition()
    //записываем данные 
    {
        PlayerPrefs.SetFloat("x", ClickToMove.CurrentPosition.x);
        PlayerPrefs.SetFloat("y", ClickToMove.CurrentPosition.y);
        PlayerPrefs.SetFloat("z", ClickToMove.CurrentPosition.z);
    }

     public static Vector3 readPlayerPosition()
    //читаем данные 
    {
        Vector3 position = new Vector3();
        position.x = PlayerPrefs.GetFloat("x");
        position.y = PlayerPrefs.GetFloat("y");
        position.z = PlayerPrefs.GetFloat("z");

        return position;
    }   

    public static void saveEnemyHealth(int id, int health)
    {
        PlayerPrefs.SetInt("enemyHealth" + id, health);
    }

    public static int readEnemyHealth(int id)
    {
        if (PlayerPrefs.HasKey("enemyHealth" + id))
        {
            return PlayerPrefs.GetInt("enemyHealth" + id);
        }
        else
        {
            return -1;
        }
          
    }

    void ResetData()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Reset");
            PlayerPrefs.DeleteAll();
            

            //target.health = 200;
        }
    }

}
