using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    Vector3 position;
    float speed;

    void Start()
    {
        
    }

    void Update ()
    {
       if (Input.GetMouseButton(0))
        {
            locatePosition();
            moveToPosition();
        }
    }

    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log(position);
        }
    }

    void moveToPosition() { 
        Quaternion newRotation  = Quaternion.LookRotation (position - transform.position); // высчитали новый угол
        newRotation.x = 0f;
        newRotation.z = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
    }
}
