using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Pool pool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            pool.activate(0, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            pool.activate(1, new Vector3(-2.84f, 0f, 0f), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            pool.activate(2, new Vector3(4f, 0f, 0f), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            pool.activate(3, new Vector3(2.87f, 0f, 0f), Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            pool.activate(3);
        }
    }
}
