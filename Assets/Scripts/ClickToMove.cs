using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    private Vector3 position;
    public float speed;
    public CharacterController controller;

    void Start()
    {
        position = transform.position;
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

        }
    }

    void moveToPosition() {
        if (Vector3.Distance(transform.position, position) > 1) { 
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position); // высчитали новый угол
            newRotation.x = 0f;
            newRotation.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10); //transform.rotation - текущий поворт.
            controller.SimpleMove(transform.forward * speed);
    }
    }
}
