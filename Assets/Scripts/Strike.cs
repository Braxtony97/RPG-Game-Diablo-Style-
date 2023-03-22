using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    public int speed;
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyBehaviour>().GetHit(damage);
        }
    }
}
