using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMember : MonoBehaviour
{
    public float life;
    //сколько будет существовать объект

    float timeToDie;
    
    void OnEnable()
    {
        timeToDie = life + Time.time;
    }

    void Update()
    {
        if (Time.time > timeToDie)
        {
            gameObject.SetActive(false);
        }
    }
}
